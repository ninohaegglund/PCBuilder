using PCBuilder.Services.ComponentsAPI.Data;
using PCBuilder.Service.ComponentsAPI.Models;

public static class DbSeeder
{
    public static void Seed(DataContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));

        // Prevent duplicate seeding
        if (context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().Any())
            return;

        var manufacturers = new List<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>
        {
            new() { Name = "Intel" },
            new() { Name = "AMD" },
            new() { Name = "NVIDIA" },
            new() { Name = "Corsair" },
            new() { Name = "ASUS" },
            new() { Name = "MSI" },
            new() { Name = "Gigabyte" },
            new() { Name = "Kingston" },
            new() { Name = "Seagate" },
            new() { Name = "Western Digital" },
            new() { Name = "Samsung" },
            new() { Name = "Logitech" },
            new() { Name = "SteelSeries" },
            new() { Name = "NZXT" },
            new() { Name = "be quiet!" },
            new() { Name = "AOC" },
            new() { Name = "Razer" },
            new() { Name = "Creative" },
            new() { Name = "EVGA" },
            new() { Name = "Thermaltake" },
            new() { Name = "Fractal Design" },
            new() { Name = "Philips" },
            new() { Name = "Dell" },
            new() { Name = "HP" },
            new() { Name = "Lenovo" }
        };

        var formFactors = new List<PCBuilder.Service.ComponentsAPI.Models.FormFactor>
        {
            new() { Name = "ATX" },
            new() { Name = "Micro-ATX" },
            new() { Name = "Mini-ITX" },
            new() { Name = "E-ATX" },
            new() { Name = "XL-ATX" }
        };

        // Seed lookup tables first
        context.AddRange(manufacturers);
        context.AddRange(formFactors);
        context.SaveChanges();

        // Re-load lookup IDs
        var intel = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Intel");
        var amd = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "AMD");
        var nvidia = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "NVIDIA");
        var corsair = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Corsair");
        var asus = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "ASUS");
        var msi = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "MSI");
        var gigabyte = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Gigabyte");
        var kingston = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Kingston");
        var seagate = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Seagate");
        var wd = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Western Digital");
        var samsung = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Samsung");
        var logitech = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Logitech");
        var steelseries = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "SteelSeries");
        var nzxt = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "NZXT");
        var beQuiet = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "be quiet!");
        var aoc = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "AOC");
        var razer = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Razer");
        var creative = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Creative");
        var evga = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "EVGA");
        var thermaltake = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Thermaltake");
        var fractal = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Fractal Design");
        var philips = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Philips");
        var dell = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Dell");
        var hp = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "HP");
        var lenovo = context.Set<PCBuilder.Service.ComponentsAPI.Models.Manufacturer>().First(x => x.Name == "Lenovo");

        var atx = context.Set<PCBuilder.Service.ComponentsAPI.Models.FormFactor>().First(x => x.Name == "ATX");
        var matx = context.Set<PCBuilder.Service.ComponentsAPI.Models.FormFactor>().First(x => x.Name == "Micro-ATX");
        var mitx = context.Set<PCBuilder.Service.ComponentsAPI.Models.FormFactor>().First(x => x.Name == "Mini-ITX");
        var eatx = context.Set<PCBuilder.Service.ComponentsAPI.Models.FormFactor>().First(x => x.Name == "E-ATX");
        var xlatx = context.Set<PCBuilder.Service.ComponentsAPI.Models.FormFactor>().First(x => x.Name == "XL-ATX");

        var cpus = new List<PCBuilder.Service.ComponentsAPI.Models.Cpu>
        {
            new() { Name = "Core i3-14100F", ManufacturerId = intel.Id, CoreCount = 4, CoreClock = 3.5m, BoostClock = 4.7m, Microarchitecture = "Raptor Lake", Tdp = 58, IntegratedGraphics = "No", Price = 1299m },
            new() { Name = "Ryzen 5 7600", ManufacturerId = amd.Id, CoreCount = 6, CoreClock = 3.8m, BoostClock = 5.1m, Microarchitecture = "Zen 4", Tdp = 65, IntegratedGraphics = "Radeon Graphics", Price = 2499m },
            new() { Name = "Core i5-14600K", ManufacturerId = intel.Id, CoreCount = 14, CoreClock = 3.5m, BoostClock = 5.3m, Microarchitecture = "Raptor Lake Refresh", Tdp = 125, IntegratedGraphics = "UHD 770", Price = 3799m },
            new() { Name = "Ryzen 7 7800X3D", ManufacturerId = amd.Id, CoreCount = 8, CoreClock = 4.2m, BoostClock = 5.0m, Microarchitecture = "Zen 4", Tdp = 120, IntegratedGraphics = "Radeon Graphics", Price = 4899m },
            new() { Name = "Core i9-14900KS", ManufacturerId = intel.Id, CoreCount = 24, CoreClock = 3.2m, BoostClock = 6.2m, Microarchitecture = "Raptor Lake Refresh", Tdp = 150, IntegratedGraphics = "UHD 770", Price = 7999m }
        };

        var gpus = new List<PCBuilder.Service.ComponentsAPI.Models.VideoCard>
        {
            new() { Name = "GeForce RTX 4060", ManufacturerId = nvidia.Id, Chipset = "AD107", MemoryGB = 8, CoreClock = 1830, BoostClock = 2460, LengthMM = 240, Price = 3999m },
            new() { Name = "Radeon RX 7600", ManufacturerId = amd.Id, Chipset = "Navi 33", MemoryGB = 8, CoreClock = 1720, BoostClock = 2655, LengthMM = 244, Price = 3299m },
            new() { Name = "GeForce RTX 4070 Super", ManufacturerId = nvidia.Id, Chipset = "AD104", MemoryGB = 12, CoreClock = 1980, BoostClock = 2475, LengthMM = 267, Price = 6799m },
            new() { Name = "Radeon RX 7900 XTX", ManufacturerId = amd.Id, Chipset = "Navi 31", MemoryGB = 24, CoreClock = 1855, BoostClock = 2499, LengthMM = 287, Price = 11999m },
            new() { Name = "GeForce RTX 4090", ManufacturerId = nvidia.Id, Chipset = "AD102", MemoryGB = 24, CoreClock = 2235, BoostClock = 2520, LengthMM = 304, Price = 18999m }
        };

        var rams = new List<PCBuilder.Service.ComponentsAPI.Models.MemoryKit>
        {
            new() { Name = "FURY Beast 16GB", TotalCapacityGB = 16, ManufacturerId = kingston.Id, ModulesCount = 2, SpeedMTs = 3200, CasLatency = 16, FirstWordLatency = 10.0m, Price = 599m },
            new() { Name = "Vengeance LPX 16GB", TotalCapacityGB = 16, ManufacturerId = corsair.Id, ModulesCount = 2, SpeedMTs = 3600, CasLatency = 18, FirstWordLatency = 10.0m, Price = 699m },
            new() { Name = "FURY Renegade 32GB", TotalCapacityGB = 32, ManufacturerId = kingston.Id, ModulesCount = 2, SpeedMTs = 6000, CasLatency = 30, FirstWordLatency = 10.0m, Price = 1499m },
            new() { Name = "Vengeance RGB 32GB", TotalCapacityGB = 32, ManufacturerId = corsair.Id, ModulesCount = 2, SpeedMTs = 6400, CasLatency = 32, FirstWordLatency = 10.0m, Price = 1799m },
            new() { Name = "Dominator Platinum 64GB", TotalCapacityGB = 64, ManufacturerId = corsair.Id, ModulesCount = 2, SpeedMTs = 6600, CasLatency = 32, FirstWordLatency = 10.0m, Price = 2999m }
        };

        var motherboards = new List<PCBuilder.Service.ComponentsAPI.Models.Motherboard>
        {
            new() { Name = "PRIME B760M-A", ManufacturerId = asus.Id, Socket = "LGA1700", FormFactorId = matx.Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = false, Price = 1999m },
            new() { Name = "MAG B650 TOMAHAWK", ManufacturerId = msi.Id, Socket = "AM5", FormFactorId = atx.Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = true, Price = 3199m },
            new() { Name = "ROG STRIX Z790-E", ManufacturerId = asus.Id, Socket = "LGA1700", FormFactorId = atx.Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = true, Price = 5499m },
            new() { Name = "X670E AORUS MASTER", ManufacturerId = gigabyte.Id, Socket = "AM5", FormFactorId = eatx.Id, MaxMemoryGB = 256, MemorySlots = 4, HasWiFi = true, Price = 6999m },
            new() { Name = "ROG CROSSHAIR X670E EXTREME", ManufacturerId = asus.Id, Socket = "AM5", FormFactorId = eatx.Id, MaxMemoryGB = 256, MemorySlots = 4, HasWiFi = true, Price = 9999m }
        };

        var cases = new List<PCBuilder.Service.ComponentsAPI.Models.Case>
        {
            new() { Name = "Pop Mini Air", ManufacturerId = fractal.Id, Type = "Mini Tower", IncludedPowerSupplyWatts = null, SidePanel = "Tempered Glass", ExternalVolumeLiters = 37.0m, Internal35Bays = 2, Price = 1199m },
            new() { Name = "H510 Flow", ManufacturerId = nzxt.Id, Type = "Mid Tower", IncludedPowerSupplyWatts = null, SidePanel = "Tempered Glass", ExternalVolumeLiters = 47.1m, Internal35Bays = 2, Price = 999m },
            new() { Name = "Meshify 2 Compact", ManufacturerId = fractal.Id, Type = "Mid Tower", IncludedPowerSupplyWatts = null, SidePanel = "Tempered Glass", ExternalVolumeLiters = 40.0m, Internal35Bays = 2, Price = 1499m },
            new() { Name = "Define 7", ManufacturerId = fractal.Id, Type = "Mid Tower", IncludedPowerSupplyWatts = null, SidePanel = "Solid", ExternalVolumeLiters = 45.5m, Internal35Bays = 6, Price = 1799m },
            new() { Name = "View 51", ManufacturerId = thermaltake.Id, Type = "Full Tower", IncludedPowerSupplyWatts = null, SidePanel = "Tempered Glass", ExternalVolumeLiters = 88.0m, Internal35Bays = 4, Price = 2299m }
        };

        // ... to be continued similarly for the remaining lists ...

        context.AddRange(cpus);
        context.AddRange(gpus);
        context.AddRange(rams);
        context.AddRange(motherboards);
        context.AddRange(cases);

        context.SaveChanges();
    }
}