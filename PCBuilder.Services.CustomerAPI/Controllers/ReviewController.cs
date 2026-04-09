using Microsoft.AspNetCore.Mvc;
using PCBuilder.Services.CustomerAPI.Response;
using PCBuilder.Services.CustomerAPI.IServices;

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
        return await _service.GetAllReviews();
    }

    [HttpGet]
    [Route("customer/{id:int}")]
    public async Task<ResponseDTO> GetReviewsByCustomerId(int id)
    {
        return await _service.GetReviewsByCustomerId(id);
    }
}
