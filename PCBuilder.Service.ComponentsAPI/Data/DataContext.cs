using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCBuilder.Service.ComponentsAPI.Models;
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

    public DbSet<Components> Components { get; set; } = null!;
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
    public DbSet<DisplayMonitor> Monitors { get; set; } = null!;
    public DbSet<Speaker> Speakers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CPU>().ToTable("CPUs");
        modelBuilder.Entity<CPUCooling>().ToTable("CPUCoolers");
        modelBuilder.Entity<Motherboard>().ToTable("Motherboards");
        modelBuilder.Entity<PSU>().ToTable("PSUs");
        modelBuilder.Entity<Chassi>().ToTable("Cases");
        modelBuilder.Entity<Keyboard>().ToTable("Keyboards");
        modelBuilder.Entity<Mouse>().ToTable("Mice");
        modelBuilder.Entity<Headset>().ToTable("Headsets");
        modelBuilder.Entity<GPU>().ToTable("GPUs");  
        modelBuilder.Entity<RAM>().ToTable("RAMModules");
        modelBuilder.Entity<StorageDevice>().ToTable("Storages");
        modelBuilder.Entity<ChassiCooling>().ToTable("ChassiCooling");
        modelBuilder.Entity<DisplayMonitor>().ToTable("Monitors");
        modelBuilder.Entity<Speaker>().ToTable("Speakers");
        modelBuilder.Entity<Components>().ToTable("Components");

        // Automatically apply enum to string conversion for all enum properties
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
    }
}