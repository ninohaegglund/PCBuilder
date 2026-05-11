using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PCBuilder.Service.BuilderServiceAPI.Data;
using PCBuilder.Services.CustomerAPI.Data;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.Models;
using PCBuilder.Services.InventoryAPI.Data;
using PCBuilder.Services.InventoryAPI.Models;
using PCBuilder.Web.ViewModels.Reviews;

namespace PCBuilder.Web.Controllers;

[Authorize]
public class ReviewsController : Controller
{
    private const decimal StartingBalance = 10000m;

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly CustomerDbContext _customerDbContext;
    private readonly InventoryDbContext _inventoryDbContext;
    private readonly BuildDataContext _buildDataContext;

    public ReviewsController(
        IHttpClientFactory httpClientFactory,
        IHttpContextAccessor httpContextAccessor,
        CustomerDbContext customerDbContext,
        InventoryDbContext inventoryDbContext,
        BuildDataContext buildDataContext)
    {
        _httpClientFactory = httpClientFactory;
        _httpContextAccessor = httpContextAccessor;
        _customerDbContext = customerDbContext;
        _inventoryDbContext = inventoryDbContext;
        _buildDataContext = buildDataContext;
    }

    public async Task<IActionResult> Index()
    {
        if (!TryGetCurrentUserId(out var userId))
        {
            TempData["error"] = "You must be logged in to view reviews.";
            return RedirectToAction("Index", "Home");
        }

        var orders = await _customerDbContext.Orders
            .Where(x => x.UserId == userId && x.Status == PCBuilder.Services.CustomerAPI.Models.OrderStatus.Completed && x.ReviewId > 0)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        var reviews = await LoadReviewsAsync();
        var reviewsById = reviews.ToDictionary(x => x.Id);
        var regeneratedAny = false;

        foreach (var order in orders)
        {
            if (reviewsById.TryGetValue(order.ReviewId, out var review) &&
                (IsTechnicalReviewText(review.Comment) || IsTechnicalReviewText(review.Title)))
            {
                await GenerateReviewAsync(order.Id);
                regeneratedAny = true;
            }
        }

        if (regeneratedAny)
        {
            reviews = await LoadReviewsAsync();
            reviewsById = reviews.ToDictionary(x => x.Id);
        }

        var customerIds = orders
            .Select(order => order.CustomerId)
            .Distinct()
            .ToList();
        var customersById = await _customerDbContext.Customers
            .Where(x => customerIds.Contains(x.Id))
            .ToDictionaryAsync(x => x.Id);

        var reviewItems = orders
            .Where(order => reviewsById.ContainsKey(order.ReviewId))
            .Select(order =>
            {
                var review = reviewsById[order.ReviewId];
                customersById.TryGetValue(order.CustomerId, out var customer);

                return new CustomerReviewItemViewModel
                {
                    OrderId = order.Id,
                    CustomerName = customer?.Name ?? "Customer",
                    CustomerImageUrl = customer?.ImageUrl ?? string.Empty,
                    OrderDescription = order.Description,
                    ReviewText = review.Comment ?? review.Title ?? "The customer left no written comment.",
                    Rating = Math.Clamp(review.Rating, 1, 5),
                    SellingPrice = order.SellingPrice,
                    CreatedAt = review.CreatedDate
                };
            })
            .ToList();

        var averageRating = reviewItems.Any()
            ? (decimal)reviewItems.Average(x => x.Rating)
            : 0m;

        var viewModel = new ReviewsIndexViewModel
        {
            Reviews = reviewItems,
            AverageRating = averageRating,
            IsGameOver = IsGameOver(reviewItems.Count, averageRating)
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> StartOver()
    {
        if (!TryGetCurrentUserId(out var userId))
        {
            TempData["error"] = "You must be logged in to start over.";
            return RedirectToAction("Index", "Home");
        }

        var userOrders = await _customerDbContext.Orders
            .Where(x => x.UserId == userId)
            .ToListAsync();

        var reviewIds = userOrders
            .Where(x => x.ReviewId > 0)
            .Select(x => x.ReviewId)
            .Distinct()
            .ToList();
        var computerIds = userOrders
            .Where(x => x.ComputerId.HasValue)
            .Select(x => x.ComputerId!.Value)
            .Distinct()
            .ToList();

        if (reviewIds.Any())
        {
            var reviews = await _customerDbContext.Reviews
                .Where(x => reviewIds.Contains(x.Id))
                .ToListAsync();
            _customerDbContext.Reviews.RemoveRange(reviews);
        }

        _customerDbContext.Orders.RemoveRange(userOrders);
        await _customerDbContext.SaveChangesAsync();

        if (computerIds.Any())
        {
            var computers = await _buildDataContext.Computers
                .Where(x => computerIds.Contains(x.Id))
                .ToListAsync();
            _buildDataContext.Computers.RemoveRange(computers);
            await _buildDataContext.SaveChangesAsync();
        }

        var inventoryItems = await _inventoryDbContext.InventoryItems
            .Where(x => x.UserId == userId)
            .ToListAsync();
        _inventoryDbContext.InventoryItems.RemoveRange(inventoryItems);

        var wallet = await _inventoryDbContext.Wallets.FirstOrDefaultAsync(x => x.UserId == userId);
        if (wallet == null)
        {
            _inventoryDbContext.Wallets.Add(new Wallet
            {
                UserId = userId,
                Balance = StartingBalance,
                CreatedAt = DateTime.UtcNow
            });
        }
        else
        {
            wallet.Balance = StartingBalance;
            wallet.UpdatedAt = DateTime.UtcNow;
        }

        await _inventoryDbContext.SaveChangesAsync();

        TempData["success"] = "Progress reset. You are starting over with 10 000 kr.";
        return RedirectToAction("OrderIndex", "Order");
    }

    private async Task<List<Review>> LoadReviewsAsync()
    {
        var response = await SendCustomerApiAsync(HttpMethod.Get, "api/reviews");
        if (response.Result == null)
        {
            return new List<Review>();
        }

        return JsonConvert.DeserializeObject<List<Review>>(
            JsonConvert.SerializeObject(response.Result)) ?? new List<Review>();
    }

    private Task<ResponseDTO> GenerateReviewAsync(int orderId)
    {
        return SendCustomerApiAsync(HttpMethod.Post, "api/reviews", orderId);
    }

    private async Task<ResponseDTO> SendCustomerApiAsync(HttpMethod method, string url, object? data = null)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("CustomerAPI");
            using var request = new HttpRequestMessage(method, url);

            var token = _httpContextAccessor.HttpContext?.Session.GetString("AuthToken");
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            if (data != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            }

            using var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return !string.IsNullOrWhiteSpace(content)
                ? JsonConvert.DeserializeObject<ResponseDTO>(content) ?? new ResponseDTO { IsSuccess = false }
                : new ResponseDTO { IsSuccess = response.IsSuccessStatusCode };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }

    private bool TryGetCurrentUserId(out Guid userId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userIdClaim, out userId);
    }

    private static bool IsGameOver(int reviewCount, decimal averageRating)
    {
        return reviewCount >= 3 && averageRating < 2.5m;
    }

    private static bool IsTechnicalReviewText(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return false;
        }

        return text.Contains("Error mapping types", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("Missing type map configuration", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("Object serialized", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("Exception", StringComparison.OrdinalIgnoreCase);
    }
}
