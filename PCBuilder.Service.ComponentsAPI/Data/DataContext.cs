using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using PCBuilder.Services.ComponentsAPI.Models;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables.PCIe;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Chassi;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling.PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Headsets;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Keyboards.PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Keyboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Mice;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Monitors;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Speakers;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Motherboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.PSUs;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.RAM;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

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
    public DbSet<Storage> Storages { get; set; } = null!;
    public DbSet<ChassiCooling> CaseFans { get; set; } = null!;
    public DbSet<PCIeCable> PCIeCables { get; set; } = null!;
    public DbSet<PowerCable> PowerCables { get; set; } = null!;
    public DbSet<SataCable> SataCables { get; set; } = null!;
    public DbSet<DisplayMonitor> Monitors { get; set; } = null!;
    public DbSet<Speaker> Speakers { get; set; } = null!;
}