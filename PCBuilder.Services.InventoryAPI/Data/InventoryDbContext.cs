using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.InventoryAPI.Models;

namespace PCBuilder.Services.InventoryAPI.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext   > options) : base(options) { }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<Wallet> Wallets { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Wallet>()
            .HasIndex(x => x.UserId)
            .IsUnique();

        modelBuilder.Entity<InventoryItem>()
            .HasIndex(x => new { x.UserId, x.ComponentType, x.ComponentId })
            .IsUnique();
    }

}
