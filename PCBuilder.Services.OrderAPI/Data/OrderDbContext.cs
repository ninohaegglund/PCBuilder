using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.OrderAPI.Models;

namespace PCBuilder.Services.OrderAPI.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "RTX 5090",
                Price = 2000000,
                Description = "FAST AS FUCK",
                CategoryName = "GPU",
                ImageUrl = "https://cdn.webhallen.com/images/product/378145?trim&w=1400"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "RTX 5070 Ti",
                Price = 3000000,
                Description = "FAST AF",
                CategoryName = "GPU",
                ImageUrl = "https://cdn.webhallen.com/images/product/378849?trim&w=1400"
            });

        }
    }
}
