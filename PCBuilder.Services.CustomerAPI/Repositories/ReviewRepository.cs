using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.CustomerAPI.Data;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Services.CustomerAPI.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly CustomerDbContext _context;
    public ReviewRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Review>> GetAllReviews()
    {
        var reviews = await _context.Reviews.ToListAsync();
        return reviews;
    }

    public async Task<Review?> GetReviewById(int id)
    {
        var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
        return review;
    }
}
