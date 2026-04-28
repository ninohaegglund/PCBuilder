using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Web.ViewModels.Account;

namespace PCBuilder.Web.Controllers;

public class AccountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AccountController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewData["ReturnUrl"] = returnUrl;
        return View(new LoginViewModel());
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        var client = _httpClientFactory.CreateClient("IdentityAPI");
        var response = await client.PostAsJsonAsync("api/auth/login", new
        {
            model.Email,
            model.Password
        });

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, await ExtractErrorMessageAsync(response));
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        var authResponse = await response.Content.ReadFromJsonAsync<AuthApiResponse>(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (authResponse?.User == null || string.IsNullOrWhiteSpace(authResponse.Token))
        {
            ModelState.AddModelError(string.Empty, "Login failed.");
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        await SignInUserAsync(authResponse);

        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }

        return RedirectToAction("Index", "Home");
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Register()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Home");
        }

        return View(new RegisterViewModel());
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var client = _httpClientFactory.CreateClient("IdentityAPI");
        var response = await client.PostAsJsonAsync("api/auth/register", new
        {
            model.FirstName,
            model.LastName,
            model.Email,
            model.Password,
            model.ConfirmPassword
        });

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, await ExtractErrorMessageAsync(response));
            return View(model);
        }

        var authResponse = await response.Content.ReadFromJsonAsync<AuthApiResponse>(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (authResponse?.User == null || string.IsNullOrWhiteSpace(authResponse.Token))
        {
            ModelState.AddModelError(string.Empty, "Registration failed.");
            return View(model);
        }

        await SignInUserAsync(authResponse);
        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Clear();
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }

    private async Task SignInUserAsync(AuthApiResponse authResponse)
    {
        HttpContext.Session.SetString("AuthToken", authResponse.Token);
        var testToken = HttpContext.Session.GetString("AuthToken");

        var currentUser = new CurrentUserViewModel
        {
            Id = authResponse.User.Id.ToString(),
            FirstName = authResponse.User.FirstName,
            LastName = authResponse.User.LastName,
            Email = authResponse.User.Email,
            Balance = authResponse.User.Balance
        };

        HttpContext.Session.SetString("CurrentUser", JsonSerializer.Serialize(currentUser));

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, authResponse.User.Id.ToString()),
            new(ClaimTypes.Name, $"{authResponse.User.FirstName} {authResponse.User.LastName}"),
            new(ClaimTypes.Email, authResponse.User.Email),
            new("access_token", authResponse.Token)
        };

        foreach (var role in authResponse.User.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = authResponse.ExpiresAt
            });
    }

    private static async Task<string> ExtractErrorMessageAsync(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(content))
        {
            return "Authentication request failed.";
        }

        try
        {
            using var document = JsonDocument.Parse(content);
            if (document.RootElement.TryGetProperty("message", out var messageElement))
            {
                var message = messageElement.GetString();
                if (!string.IsNullOrWhiteSpace(message))
                {
                    return message;
                }
            }
        }
        catch
        {
        }

        return "Authentication request failed.";
    }

    private sealed class AuthApiResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public AuthApiUser User { get; set; } = new();
    }

    private sealed class AuthApiUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public List<string> Roles { get; set; } = new();
    }
}