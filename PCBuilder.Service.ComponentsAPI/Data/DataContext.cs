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


        // CPU
        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Cpu)
            .WithMany() // flera datorer kan ha samma CPU-modell
            .HasForeignKey(c => c.CPUId);

        // PSU
        modelBuilder.Entity<Computer>()
            .HasOne(c => c.PSU)
            .WithMany()
            .HasForeignKey(c => c.PSUId);

        // Motherboard
        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Motherboard)
            .WithMany()
            .HasForeignKey(c => c.MotherboardId);

        // Case
        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Case)
            .WithMany()
            .HasForeignKey(c => c.CaseId);

        // CPU Cooler
        modelBuilder.Entity<Computer>()
            .HasOne(c => c.CPUCooler)
            .WithMany()
            .HasForeignKey(c => c.CpuCoolerId);

        // Keyboard
        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Keyboard)
            .WithMany()
            .HasForeignKey(c => c.KeyboardId);

        // Mouse
        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Mouse)
            .WithMany()
            .HasForeignKey(c => c.MouseId);

        // Headset
        modelBuilder.Entity<Computer>()
            .HasOne(c => c.Headset)
            .WithMany()
            .HasForeignKey(c => c.HeadsetId);


        // 1-many relationer
        modelBuilder.Entity<Computer>()
            .HasMany(c => c.GPU)
            .WithOne(g => g.Computer)
            .HasForeignKey(g => g.ComputerId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.RamModules)
            .WithOne(r => r.Computer)
            .HasForeignKey(r => r.ComputerId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.Storage)
            .WithOne(s => s.Computer)
            .HasForeignKey(s => s.ComputerId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.CaseFans)
            .WithOne(f => f.Computer)
            .HasForeignKey(f => f.ComputerId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.PCIeCables)
            .WithOne(pc => pc.Computer)
            .HasForeignKey(pc => pc.ComputerId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.PowerCables)
            .WithOne(pc => pc.Computer)
            .HasForeignKey(pc => pc.ComputerId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.SataCables)
            .WithOne(sc => sc.Computer)
            .HasForeignKey(sc => sc.ComputerId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.Monitor)
            .WithOne(m => m.Computer)
            .HasForeignKey(m => m.ComputerId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Computer>()
            .HasMany(c => c.Speakers)
            .WithOne(s => s.Computer)
            .HasForeignKey(s => s.ComputerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}