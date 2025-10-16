using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Services.CustomerAPI.Data;

public class CustomerDbContext : DbContext  
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }
    public DbSet<Customer> Customers { get; set; } = null!;
}
