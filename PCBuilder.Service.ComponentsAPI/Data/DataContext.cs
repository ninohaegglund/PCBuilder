using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.ComponentsAPI.Models;
using Monitor = PCBuilder.Service.ComponentsAPI.Models.Monitor;
using OperatingSystem = PCBuilder.Service.ComponentsAPI.Models.OperatingSystem;

namespace PCBuilder.Services.ComponentsAPI.Data
{
    public class DataContext : DbContext  
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Cpu> Cpus { get; set; } = null!;
        public DbSet<VideoCard> VideoCards { get; set; } = null!;
        public DbSet<MemoryKit> MemoryKits { get; set; } = null!;
        public DbSet<Motherboard> Motherboards { get; set; } = null!;
        public DbSet<Case> Cases { get; set; } = null!;
        public DbSet<PowerSupply> PowerSupplies { get; set; } = null!;
        public DbSet<CpuCooler> CpuCoolers { get; set; } = null!;
        public DbSet<CaseFan> CaseFans { get; set; } = null!;
        public DbSet<InternalHardDrive> InternalHardDrives { get; set; } = null!;
        public DbSet<ExternalHardDrive> ExternalHardDrives { get; set; } = null!;
        public DbSet<Monitor> Monitors { get; set; } = null!;
        public DbSet<Mouse> Mice { get; set; } = null!;
        public DbSet<Keyboard> Keyboards { get; set; } = null!;
        public DbSet<Headphones> Headphones { get; set; } = null!;
        public DbSet<Speakers> Speakers { get; set; } = null!;
        public DbSet<Webcam> Webcams { get; set; } = null!;
        public DbSet<FanController> FanControllers { get; set; } = null!;
        public DbSet<WirelessNetworkCard> WirelessNetworkCards { get; set; } = null!;
        public DbSet<WiredNetworkCard> WiredNetworkCards { get; set; } = null!;
        public DbSet<SoundCard> SoundCards { get; set; } = null!;
        public DbSet<ThermalPaste> ThermalPastes { get; set; } = null!;
        public DbSet<Ups> UpsSystems { get; set; } = null!;
        public DbSet<OpticalDrive> OpticalDrives { get; set; } = null!;
        public DbSet<OperatingSystem> OperatingSystems { get; set; } = null!;
        public DbSet<CaseAccessory> CaseAccessories { get; set; } = null!;

        // Lookup tables
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<FormFactor> FormFactors { get; set; } = null!;

        // ────────────────── OnModelCreating ──────────────────
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table names
            modelBuilder.Entity<Cpu>().ToTable("CPUs");
            modelBuilder.Entity<VideoCard>().ToTable("GPUs");
            modelBuilder.Entity<MemoryKit>().ToTable("RAMModules");
            modelBuilder.Entity<Motherboard>().ToTable("Motherboards");
            modelBuilder.Entity<Case>().ToTable("Cases");
            modelBuilder.Entity<PowerSupply>().ToTable("PSUs");
            modelBuilder.Entity<CpuCooler>().ToTable("CPUCoolers");
            modelBuilder.Entity<CaseFan>().ToTable("ChassiCooling");
            modelBuilder.Entity<InternalHardDrive>().ToTable("Storages");
            modelBuilder.Entity<ExternalHardDrive>().ToTable("ExternalStorages");
            modelBuilder.Entity<Monitor>().ToTable("Monitors");
            modelBuilder.Entity<Mouse>().ToTable("Mice");
            modelBuilder.Entity<Keyboard>().ToTable("Keyboards");
            modelBuilder.Entity<Headphones>().ToTable("Headsets");
            modelBuilder.Entity<Speakers>().ToTable("Speakers");
            modelBuilder.Entity<Webcam>().ToTable("Webcams");
            modelBuilder.Entity<FanController>().ToTable("FanControllers");
            modelBuilder.Entity<WirelessNetworkCard>().ToTable("WirelessNetworkCards");
            modelBuilder.Entity<WiredNetworkCard>().ToTable("WiredNetworkCards");
            modelBuilder.Entity<SoundCard>().ToTable("SoundCards");
            modelBuilder.Entity<ThermalPaste>().ToTable("ThermalPastes");
            modelBuilder.Entity<Ups>().ToTable("UPS");
            modelBuilder.Entity<OpticalDrive>().ToTable("OpticalDrives");
            modelBuilder.Entity<OperatingSystem>().ToTable("OperatingSystems");
            modelBuilder.Entity<CaseAccessory>().ToTable("CaseAccessories");

            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturers");
            modelBuilder.Entity<Color>().ToTable("Colors");
            modelBuilder.Entity<FormFactor>().ToTable("FormFactors");

            // Indexes
            modelBuilder.Entity<Cpu>(e => e.HasIndex(x => x.ManufacturerId));
            modelBuilder.Entity<VideoCard>(e =>
            {
                e.HasIndex(x => x.ManufacturerId);
                e.HasIndex(x => x.ColorId);
            });
            modelBuilder.Entity<Motherboard>(e =>
            {
                e.HasIndex(x => x.ManufacturerId);
                e.HasIndex(x => x.ColorId);
                e.HasIndex(x => x.Socket);
            });
            modelBuilder.Entity<Case>(e => e.HasIndex(x => x.ColorId));
            modelBuilder.Entity<PowerSupply>(e => e.HasIndex(x => x.ColorId));
            modelBuilder.Entity<CpuCooler>(e => e.HasIndex(x => x.ColorId));
        }
    }
}