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
        public DbSet<SoundCard> SoundCards { get; set; } = null!;
        public DbSet<Ups> UpsSystems { get; set; } = null!;
        public DbSet<OperatingSystem> OperatingSystems { get; set; } = null!;
        public DbSet<CaseAccessory> CaseAccessories { get; set; } = null!;

        // Lookup tables
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<FormFactor> FormFactors { get; set; } = null!;

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
            modelBuilder.Entity<SoundCard>().ToTable("SoundCards");
            modelBuilder.Entity<Ups>().ToTable("UPS");
            modelBuilder.Entity<OperatingSystem>().ToTable("OperatingSystems");
            modelBuilder.Entity<CaseAccessory>().ToTable("CaseAccessories");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturers");
            modelBuilder.Entity<FormFactor>().ToTable("FormFactors");

            // Relationships
            modelBuilder.Entity<Cpu>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VideoCard>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MemoryKit>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Motherboard>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Motherboard>()
                .HasOne(x => x.FormFactor)
                .WithMany()
                .HasForeignKey(x => x.FormFactorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Case>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PowerSupply>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CpuCooler>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CaseFan>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InternalHardDrive>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExternalHardDrive>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Monitor>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Mouse>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Keyboard>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Headphones>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Speakers>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Webcam>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FanController>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SoundCard>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ups>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OperatingSystem>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CaseAccessory>()
                .HasOne(x => x.Manufacturer)
                .WithMany()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cpu>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<VideoCard>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<MemoryKit>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<Motherboard>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<Motherboard>().HasIndex(x => x.Socket);
            modelBuilder.Entity<Case>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<PowerSupply>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<CpuCooler>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<CaseFan>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<InternalHardDrive>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<ExternalHardDrive>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<Monitor>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<Mouse>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<Keyboard>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<Headphones>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<Speakers>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<Webcam>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<FanController>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<SoundCard>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<Ups>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<OperatingSystem>().HasIndex(x => x.ManufacturerId);
            modelBuilder.Entity<CaseAccessory>().HasIndex(x => x.ManufacturerId);
        }
    }
}