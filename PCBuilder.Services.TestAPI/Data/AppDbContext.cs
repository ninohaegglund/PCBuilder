using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.TestAPI.Models;

namespace PCBuilder.Services.TestAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Coupon> Coupons { get; set; }
}
