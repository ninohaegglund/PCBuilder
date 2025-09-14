using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCBuilder.Services.ComponentsAPI.Models;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables.PCIe;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Chassi;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Headsets;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Keyboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Mice;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Speakers;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Motherboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.PSUs;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.RAM;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.StorageDevice;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Computer> Computers { get; set; } = null!;
    public DbSet<CPU> CPUs { get; set; } = null!;
    public DbSet<CPUCooling> CPUCoolers { get; set; } = null!;
    public DbSet<Motherboard> Motherboards { get; set; } = null!;
    public DbSet<PSU> PSUs { get; set; } = null!;
    public DbSet<Chassi> Cases { get; set; } = null!;
    public DbSet<Keyboard> Keyboards { get; set; } = null!;
    public DbSet<Mouse> Mice { get; set; } = null!;
    public DbSet<Headset> Headsets { get; set; } = null!;
    public DbSet<GPU> GPUs { get; set; } = null!;
    public DbSet<RAM> RAMModules { get; set; } = null!;
    public DbSet<StorageDevice> Storages { get; set; } = null!;
    public DbSet<ChassiCooling> ChassiCooling { get; set; } = null!;
    public DbSet<PCIeCable> PCIeCables { get; set; } = null!;
    public DbSet<PowerCable> PowerCables { get; set; } = null!;
    public DbSet<SataCable> SataCables { get; set; } = null!;
    public DbSet<DisplayMonitor> Monitors { get; set; } = null!;
    public DbSet<Speaker> Speakers { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Enums sparas som string
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType.IsEnum)
                {
                    var converterType = typeof(EnumToStringConverter<>).MakeGenericType(property.ClrType);
                    var converter = Activator.CreateInstance(converterType) as ValueConverter;
                    property.SetValueConverter(converter);
                }
            }
        }


        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Cpu)
            .WithOne()
            .HasForeignKey<Computer>(c => c.CPUId);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.PSU)
            .WithOne()
            .HasForeignKey<Computer>(c => c.PSUId);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Motherboard)
            .WithOne()
            .HasForeignKey<Computer>(c => c.MotherboardId);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Case)
            .WithOne()
            .HasForeignKey<Computer>(c => c.CaseId);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.CPUCooler)
            .WithOne()
            .HasForeignKey<Computer>(c => c.CpuCoolerId);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Keyboard)
            .WithOne()
            .HasForeignKey<Computer>(c => c.KeyboardId);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Mouse)
            .WithOne()
            .HasForeignKey<Computer>(c => c.MouseId);

        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Headset)
            .WithOne()
            .HasForeignKey<Computer>(c => c.HeadsetId);

        // 1-many relationer
        modelBuilder.Entity<Computer>()
            .HasMany(c => c.GPU)
            .WithOne(g => g.Computer)
            .HasForeignKey(g => g.ComputerId);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.RamModules)
            .WithOne(r => r.Computer)
            .HasForeignKey(r => r.ComputerId);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.Storage)
            .WithOne(s => s.Computer)
            .HasForeignKey(s => s.ComputerId);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.CaseFans)
            .WithOne(f => f.Computer)
            .HasForeignKey(f => f.ComputerId);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.PCIeCables)
            .WithOne(pc => pc.Computer)
            .HasForeignKey(pc => pc.ComputerId);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.PowerCables)
            .WithOne(pc => pc.Computer)
            .HasForeignKey(pc => pc.ComputerId);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.SataCables)
            .WithOne(sc => sc.Computer)
            .HasForeignKey(sc => sc.ComputerId);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.Monitor)
            .WithOne(m => m.Computer)
            .HasForeignKey(m => m.ComputerId);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.Speakers)
            .WithOne(s => s.Computer)
            .HasForeignKey(s => s.ComputerId);
    }
}