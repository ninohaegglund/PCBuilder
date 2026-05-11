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

    public async Task<List<Review>> GetReviewsByIds(IEnumerable<int> ids)
    {
        var reviewIds = ids.ToHashSet();
        return await _context.Reviews
            .Where(r => reviewIds.Contains(r.Id))
            .ToListAsync();
    }

    public async Task AddReview(Review review)
    {
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateReview(Review review)
    {
        _context.Reviews.Update(review);
        await _context.SaveChangesAsync();
    }
}
