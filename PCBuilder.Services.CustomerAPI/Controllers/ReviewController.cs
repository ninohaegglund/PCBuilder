using Microsoft.AspNetCore.Mvc;
using PCBuilder.Services.CustomerAPI.Response;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.DTO;

namespace PCBuilder.Services.CustomerAPI.Controllers;

[Route("api/reviews")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _service;

    [HttpGet]
    [Route("{id:int}")]
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

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ResponseDTO> CreateReviewForComputer(BuildReviewRequestDto info)
    {
        return await _service.(info);
    }
}
