using Microsoft.AspNetCore.Mvc;
using Contracts;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO;

namespace PCBuilder.Services.CustomerAPI.Controllers;

[Route("api/reviews")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _service;

    public ReviewController(IReviewService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ResponseDTO> GetAllReviews()
    {
        return await _service.GetAllReviewsAsync();
    }

    [HttpGet]
    [Route("customer/{id:int}")]
    public async Task<ResponseDTO> GetReviewsByCustomerId(int id)
    {
        return await _service.GetReviewsByCustomerIdAsync(id);
    }

    [HttpPost]
    public async Task<ResponseDTO> CreateReviewForComputer([FromBody] int orderId)
    {
        return await _service.GenerateReviewAsync(orderId);
    }
}
