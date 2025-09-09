using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.TestAPI.Models;

namespace PCBuilder.Services.TestAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Coupon> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Coupon>().HasData( new Coupon
        {
            CouponId = 1,
            CouponCode = "10OFF",
            Discount = 10,
            MinAmount = 50
        });
        modelBuilder.Entity<Coupon>().HasData( new Coupon
        {
            CouponId = 2,
            CouponCode = "20OFF",
            Discount = 20,
            MinAmount = 40
        });

    }
}
