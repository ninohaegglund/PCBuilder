using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Services.ComponentsAPI.Data;
using Monitor = PCBuilder.Service.ComponentsAPI.Models.Monitor;
using OperatingSystem = PCBuilder.Service.ComponentsAPI.Models.OperatingSystem;

public static class DbSeeder
{
    public static void Seed(DataContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));

        SeedLookups(context);

        var manufacturers = context.Manufacturers.ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);
        var formFactors = context.FormFactors.ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);

        AddIfEmpty(context, context.Cpus, new[]
        {
            new Cpu { Name = "Core i3-12100F", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 4, CoreClock = 3.3m, BoostClock = 4.3m, Microarchitecture = "Alder Lake", Tdp = 58, IntegratedGraphics = "No", Price = 999m },
            new Cpu { Name = "Core i3-14100F", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 4, CoreClock = 3.5m, BoostClock = 4.7m, Microarchitecture = "Raptor Lake", Tdp = 58, IntegratedGraphics = "No", Price = 1299m },
            new Cpu { Name = "Core i5-12400F", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 6, CoreClock = 2.5m, BoostClock = 4.4m, Microarchitecture = "Alder Lake", Tdp = 65, IntegratedGraphics = "No", Price = 1699m },
            new Cpu { Name = "Core i5-13400F", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 10, CoreClock = 2.5m, BoostClock = 4.6m, Microarchitecture = "Raptor Lake", Tdp = 65, IntegratedGraphics = "No", Price = 2299m },
            new Cpu { Name = "Core i5-14600K", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 14, CoreClock = 3.5m, BoostClock = 5.3m, Microarchitecture = "Raptor Lake Refresh", Tdp = 125, IntegratedGraphics = "UHD 770", Price = 3799m },
            new Cpu { Name = "Core i7-13700K", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 16, CoreClock = 3.4m, BoostClock = 5.4m, Microarchitecture = "Raptor Lake", Tdp = 125, IntegratedGraphics = "UHD 770", Price = 4499m },
            new Cpu { Name = "Core i7-14700K", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 20, CoreClock = 3.4m, BoostClock = 5.6m, Microarchitecture = "Raptor Lake Refresh", Tdp = 125, IntegratedGraphics = "UHD 770", Price = 4999m },
            new Cpu { Name = "Core i9-13900K", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 24, CoreClock = 3.0m, BoostClock = 5.8m, Microarchitecture = "Raptor Lake", Tdp = 125, IntegratedGraphics = "UHD 770", Price = 6299m },
            new Cpu { Name = "Core i9-14900K", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 24, CoreClock = 3.2m, BoostClock = 6.0m, Microarchitecture = "Raptor Lake Refresh", Tdp = 125, IntegratedGraphics = "UHD 770", Price = 6999m },
            new Cpu { Name = "Core i9-14900KS", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 24, CoreClock = 3.2m, BoostClock = 6.2m, Microarchitecture = "Raptor Lake Refresh", Tdp = 150, IntegratedGraphics = "UHD 770", Price = 7999m },

            new Cpu { Name = "Ryzen 5 5600", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 6, CoreClock = 3.5m, BoostClock = 4.4m, Microarchitecture = "Zen 3", Tdp = 65, IntegratedGraphics = "No", Price = 1399m },
            new Cpu { Name = "Ryzen 5 5600X", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 6, CoreClock = 3.7m, BoostClock = 4.6m, Microarchitecture = "Zen 3", Tdp = 65, IntegratedGraphics = "No", Price = 1699m },
            new Cpu { Name = "Ryzen 7 5700X", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 8, CoreClock = 3.4m, BoostClock = 4.6m, Microarchitecture = "Zen 3", Tdp = 65, IntegratedGraphics = "No", Price = 1999m },
            new Cpu { Name = "Ryzen 7 5800X3D", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 8, CoreClock = 3.4m, BoostClock = 4.5m, Microarchitecture = "Zen 3", Tdp = 105, IntegratedGraphics = "No", Price = 3299m },
            new Cpu { Name = "Ryzen 5 7500F", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 6, CoreClock = 3.7m, BoostClock = 5.0m, Microarchitecture = "Zen 4", Tdp = 65, IntegratedGraphics = "No", Price = 1999m },
            new Cpu { Name = "Ryzen 5 7600", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 6, CoreClock = 3.8m, BoostClock = 5.1m, Microarchitecture = "Zen 4", Tdp = 65, IntegratedGraphics = "Radeon Graphics", Price = 2499m },
            new Cpu { Name = "Ryzen 5 7600X", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 6, CoreClock = 4.7m, BoostClock = 5.3m, Microarchitecture = "Zen 4", Tdp = 105, IntegratedGraphics = "Radeon Graphics", Price = 2799m },
            new Cpu { Name = "Ryzen 7 7700", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 8, CoreClock = 3.8m, BoostClock = 5.3m, Microarchitecture = "Zen 4", Tdp = 65, IntegratedGraphics = "Radeon Graphics", Price = 3499m },
            new Cpu { Name = "Ryzen 7 7800X3D", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 8, CoreClock = 4.2m, BoostClock = 5.0m, Microarchitecture = "Zen 4", Tdp = 120, IntegratedGraphics = "Radeon Graphics", Price = 4899m },
            new Cpu { Name = "Ryzen 9 7900X", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 12, CoreClock = 4.7m, BoostClock = 5.6m, Microarchitecture = "Zen 4", Tdp = 170, IntegratedGraphics = "Radeon Graphics", Price = 4999m },
            new Cpu { Name = "Ryzen 9 7950X", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 16, CoreClock = 4.5m, BoostClock = 5.7m, Microarchitecture = "Zen 4", Tdp = 170, IntegratedGraphics = "Radeon Graphics", Price = 6999m }
        });

        AddIfEmpty(context, context.VideoCards, new[]
        {
            new VideoCard { Name = "GeForce GTX 1660 Super", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 125, Chipset = "TU116", MemoryGB = 6, CoreClock = 1530, BoostClock = 1785, LengthMM = 229, Price = 2499m },
            new VideoCard { Name = "GeForce RTX 3060", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 170, Chipset = "GA106", MemoryGB = 12, CoreClock = 1320, BoostClock = 1777, LengthMM = 242, Price = 3299m },
            new VideoCard { Name = "GeForce RTX 3060 Ti", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 200, Chipset = "GA104", MemoryGB = 8, CoreClock = 1410, BoostClock = 1665, LengthMM = 242, Price = 3999m },
            new VideoCard { Name = "GeForce RTX 4060", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 115, Chipset = "AD107", MemoryGB = 8, CoreClock = 1830, BoostClock = 2460, LengthMM = 240, Price = 3999m },
            new VideoCard { Name = "GeForce RTX 4060 Ti", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 160, Chipset = "AD106", MemoryGB = 8, CoreClock = 2310, BoostClock = 2535, LengthMM = 244, Price = 4999m },
            new VideoCard { Name = "GeForce RTX 4070", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 200, Chipset = "AD104", MemoryGB = 12, CoreClock = 1920, BoostClock = 2475, LengthMM = 242, Price = 6299m },
            new VideoCard { Name = "GeForce RTX 4070 Super", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 220, Chipset = "AD104", MemoryGB = 12, CoreClock = 1980, BoostClock = 2475, LengthMM = 267, Price = 6799m },
            new VideoCard { Name = "GeForce RTX 4070 Ti Super", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 285, Chipset = "AD103", MemoryGB = 16, CoreClock = 2340, BoostClock = 2610, LengthMM = 305, Price = 9999m },
            new VideoCard { Name = "GeForce RTX 4080 Super", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 320, Chipset = "AD103", MemoryGB = 16, CoreClock = 2295, BoostClock = 2550, LengthMM = 310, Price = 12999m },
            new VideoCard { Name = "GeForce RTX 4090", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 450, Chipset = "AD102", MemoryGB = 24, CoreClock = 2235, BoostClock = 2520, LengthMM = 304, Price = 18999m },

            new VideoCard { Name = "Radeon RX 6600", ManufacturerId = manufacturers["AMD"].Id, Tdp = 132, Chipset = "Navi 23", MemoryGB = 8, CoreClock = 1626, BoostClock = 2491, LengthMM = 190, Price = 2499m },
            new VideoCard { Name = "Radeon RX 6650 XT", ManufacturerId = manufacturers["AMD"].Id, Tdp = 176, Chipset = "Navi 23", MemoryGB = 8, CoreClock = 2055, BoostClock = 2635, LengthMM = 204, Price = 2999m },
            new VideoCard { Name = "Radeon RX 7600", ManufacturerId = manufacturers["AMD"].Id, Tdp = 165, Chipset = "Navi 33", MemoryGB = 8, CoreClock = 1720, BoostClock = 2655, LengthMM = 244, Price = 3299m },
            new VideoCard { Name = "Radeon RX 7600 XT", ManufacturerId = manufacturers["AMD"].Id, Tdp = 190, Chipset = "Navi 33", MemoryGB = 16, CoreClock = 1980, BoostClock = 2755, LengthMM = 250, Price = 3999m },
            new VideoCard { Name = "Radeon RX 7700 XT", ManufacturerId = manufacturers["AMD"].Id, Tdp = 245, Chipset = "Navi 32", MemoryGB = 12, CoreClock = 1700, BoostClock = 2544, LengthMM = 267, Price = 5499m },
            new VideoCard { Name = "Radeon RX 7800 XT", ManufacturerId = manufacturers["AMD"].Id, Tdp = 263, Chipset = "Navi 32", MemoryGB = 16, CoreClock = 1800, BoostClock = 2430, LengthMM = 267, Price = 6299m },
            new VideoCard { Name = "Radeon RX 7900 GRE", ManufacturerId = manufacturers["AMD"].Id, Tdp = 260, Chipset = "Navi 31", MemoryGB = 16, CoreClock = 1287, BoostClock = 2245, LengthMM = 280, Price = 6999m },
            new VideoCard { Name = "Radeon RX 7900 XT", ManufacturerId = manufacturers["AMD"].Id, Tdp = 315, Chipset = "Navi 31", MemoryGB = 20, CoreClock = 1500, BoostClock = 2394, LengthMM = 276, Price = 8999m },
            new VideoCard { Name = "Radeon RX 7900 XTX", ManufacturerId = manufacturers["AMD"].Id, Tdp = 355, Chipset = "Navi 31", MemoryGB = 24, CoreClock = 1855, BoostClock = 2499, LengthMM = 287, Price = 11999m }
        });

        AddIfEmpty(context, context.MemoryKits, new[]
        {
            new MemoryKit { Name = "FURY Beast 16GB", TotalCapacityGB = 16, ManufacturerId = manufacturers["Kingston"].Id, ModulesCount = 2, SpeedMTs = 3200, CasLatency = 16, FirstWordLatency = 10.0m, Price = 599m },
            new MemoryKit { Name = "Vengeance LPX 16GB", TotalCapacityGB = 16, ManufacturerId = manufacturers["Corsair"].Id, ModulesCount = 2, SpeedMTs = 3600, CasLatency = 18, FirstWordLatency = 10.0m, Price = 699m },
            new MemoryKit { Name = "FURY Renegade 32GB", TotalCapacityGB = 32, ManufacturerId = manufacturers["Kingston"].Id, ModulesCount = 2, SpeedMTs = 6000, CasLatency = 30, FirstWordLatency = 10.0m, Price = 1499m },
            new MemoryKit { Name = "Vengeance RGB 32GB", TotalCapacityGB = 32, ManufacturerId = manufacturers["Corsair"].Id, ModulesCount = 2, SpeedMTs = 6400, CasLatency = 32, FirstWordLatency = 10.0m, Price = 1799m },
            new MemoryKit { Name = "Dominator Platinum 64GB", TotalCapacityGB = 64, ManufacturerId = manufacturers["Corsair"].Id, ModulesCount = 2, SpeedMTs = 6600, CasLatency = 32, FirstWordLatency = 10.0m, Price = 2999m },
            new MemoryKit { Name = "Ripjaws V 32GB", TotalCapacityGB = 32, ManufacturerId = manufacturers["G.Skill"].Id, ModulesCount = 2, SpeedMTs = 3600, CasLatency = 16, FirstWordLatency = 8.9m, Price = 1099m },
            new MemoryKit { Name = "Trident Z5 Neo 32GB", TotalCapacityGB = 32, ManufacturerId = manufacturers["G.Skill"].Id, ModulesCount = 2, SpeedMTs = 6000, CasLatency = 30, FirstWordLatency = 10.0m, Price = 1699m },
            new MemoryKit { Name = "T-Force Delta RGB 32GB", TotalCapacityGB = 32, ManufacturerId = manufacturers["TeamGroup"].Id, ModulesCount = 2, SpeedMTs = 6000, CasLatency = 30, FirstWordLatency = 10.0m, Price = 1499m },
            new MemoryKit { Name = "XPG Lancer 32GB", TotalCapacityGB = 32, ManufacturerId = manufacturers["ADATA"].Id, ModulesCount = 2, SpeedMTs = 6000, CasLatency = 30, FirstWordLatency = 10.0m, Price = 1399m },
            new MemoryKit { Name = "Vengeance 64GB DDR5", TotalCapacityGB = 64, ManufacturerId = manufacturers["Corsair"].Id, ModulesCount = 2, SpeedMTs = 6000, CasLatency = 40, FirstWordLatency = 13.3m, Price = 2499m }
        });

        AddIfEmpty(context, context.Motherboards, new[]
        {
            new Motherboard { Name = "PRIME B760M-A", ManufacturerId = manufacturers["ASUS"].Id, Socket = "LGA1700", FormFactorId = formFactors["Micro-ATX"].Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = false, Price = 1999m },
            new Motherboard { Name = "MAG B650 TOMAHAWK", ManufacturerId = manufacturers["MSI"].Id, Socket = "AM5", FormFactorId = formFactors["ATX"].Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = true, Price = 3199m },
            new Motherboard { Name = "ROG STRIX Z790-E", ManufacturerId = manufacturers["ASUS"].Id, Socket = "LGA1700", FormFactorId = formFactors["ATX"].Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = true, Price = 5499m },
            new Motherboard { Name = "X670E AORUS MASTER", ManufacturerId = manufacturers["Gigabyte"].Id, Socket = "AM5", FormFactorId = formFactors["E-ATX"].Id, MaxMemoryGB = 256, MemorySlots = 4, HasWiFi = true, Price = 6999m },
            new Motherboard { Name = "ROG CROSSHAIR X670E EXTREME", ManufacturerId = manufacturers["ASUS"].Id, Socket = "AM5", FormFactorId = formFactors["E-ATX"].Id, MaxMemoryGB = 256, MemorySlots = 4, HasWiFi = true, Price = 9999m },
            new Motherboard { Name = "B550 AORUS ELITE V2", ManufacturerId = manufacturers["Gigabyte"].Id, Socket = "AM4", FormFactorId = formFactors["ATX"].Id, MaxMemoryGB = 128, MemorySlots = 4, HasWiFi = false, Price = 1599m },
            new Motherboard { Name = "TUF GAMING B550-PLUS", ManufacturerId = manufacturers["ASUS"].Id, Socket = "AM4", FormFactorId = formFactors["ATX"].Id, MaxMemoryGB = 128, MemorySlots = 4, HasWiFi = false, Price = 1699m },
            new Motherboard { Name = "PRO B650M-A WIFI", ManufacturerId = manufacturers["MSI"].Id, Socket = "AM5", FormFactorId = formFactors["Micro-ATX"].Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = true, Price = 2299m },
            new Motherboard { Name = "B650 AORUS ELITE AX", ManufacturerId = manufacturers["Gigabyte"].Id, Socket = "AM5", FormFactorId = formFactors["ATX"].Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = true, Price = 2899m },
            new Motherboard { Name = "PRIME Z790-P WIFI", ManufacturerId = manufacturers["ASUS"].Id, Socket = "LGA1700", FormFactorId = formFactors["ATX"].Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = true, Price = 2999m },
            new Motherboard { Name = "MAG Z790 TOMAHAWK WIFI", ManufacturerId = manufacturers["MSI"].Id, Socket = "LGA1700", FormFactorId = formFactors["ATX"].Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = true, Price = 3799m },
            new Motherboard { Name = "ROG STRIX B650E-I GAMING WIFI", ManufacturerId = manufacturers["ASUS"].Id, Socket = "AM5", FormFactorId = formFactors["Mini-ITX"].Id, MaxMemoryGB = 96, MemorySlots = 2, HasWiFi = true, Price = 3999m }
        });

        AddIfEmpty(context, context.Cases, new[]
        {
            new Case { Name = "Pop Mini Air", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Mini Tower", MaxGpuLengthMm = 365, MaxCpuCoolerHeightMm = 170, FanMountCount = 5, SidePanel = "Tempered Glass", ExternalVolumeLiters = 37.0m, Internal35Bays = 2, Price = 1199m },
            new Case { Name = "H510 Flow", ManufacturerId = manufacturers["NZXT"].Id, Type = "Mid Tower", MaxGpuLengthMm = 360, MaxCpuCoolerHeightMm = 165, FanMountCount = 4, SidePanel = "Tempered Glass", ExternalVolumeLiters = 47.1m, Internal35Bays = 2, Price = 999m },
            new Case { Name = "Meshify 2 Compact", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Mid Tower", MaxGpuLengthMm = 341, MaxCpuCoolerHeightMm = 169, FanMountCount = 7, SidePanel = "Tempered Glass", ExternalVolumeLiters = 40.0m, Internal35Bays = 2, Price = 1499m },
            new Case { Name = "Define 7", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Mid Tower", MaxGpuLengthMm = 467, MaxCpuCoolerHeightMm = 185, FanMountCount = 9, SidePanel = "Solid", ExternalVolumeLiters = 45.5m, Internal35Bays = 6, Price = 1799m },
            new Case { Name = "View 51", ManufacturerId = manufacturers["Thermaltake"].Id, Type = "Full Tower", MaxGpuLengthMm = 440, MaxCpuCoolerHeightMm = 175, FanMountCount = 10, SidePanel = "Tempered Glass", ExternalVolumeLiters = 88.0m, Internal35Bays = 4, Price = 2299m },
            new Case { Name = "North", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Mid Tower", MaxGpuLengthMm = 355, MaxCpuCoolerHeightMm = 170, FanMountCount = 6, SidePanel = "Tempered Glass", ExternalVolumeLiters = 45.0m, Internal35Bays = 2, Price = 1799m },
            new Case { Name = "Torrent Compact", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Mid Tower", MaxGpuLengthMm = 330, MaxCpuCoolerHeightMm = 174, FanMountCount = 7, SidePanel = "Tempered Glass", ExternalVolumeLiters = 46.0m, Internal35Bays = 2, Price = 1899m },
            new Case { Name = "H5 Flow", ManufacturerId = manufacturers["NZXT"].Id, Type = "Mid Tower", MaxGpuLengthMm = 365, MaxCpuCoolerHeightMm = 165, FanMountCount = 6, SidePanel = "Tempered Glass", ExternalVolumeLiters = 41.0m, Internal35Bays = 1, Price = 1199m },
            new Case { Name = "H7 Flow", ManufacturerId = manufacturers["NZXT"].Id, Type = "Mid Tower", MaxGpuLengthMm = 400, MaxCpuCoolerHeightMm = 185, FanMountCount = 7, SidePanel = "Tempered Glass", ExternalVolumeLiters = 55.0m, Internal35Bays = 2, Price = 1499m },
            new Case { Name = "4000D Airflow", ManufacturerId = manufacturers["Corsair"].Id, Type = "Mid Tower", MaxGpuLengthMm = 360, MaxCpuCoolerHeightMm = 170, FanMountCount = 6, SidePanel = "Tempered Glass", ExternalVolumeLiters = 48.6m, Internal35Bays = 2, Price = 1199m },
            new Case { Name = "5000D Airflow", ManufacturerId = manufacturers["Corsair"].Id, Type = "Mid Tower", MaxGpuLengthMm = 420, MaxCpuCoolerHeightMm = 170, FanMountCount = 10, SidePanel = "Tempered Glass", ExternalVolumeLiters = 66.0m, Internal35Bays = 2, Price = 1999m },
            new Case { Name = "O11 Dynamic EVO", ManufacturerId = manufacturers["Lian Li"].Id, Type = "Mid Tower", MaxGpuLengthMm = 422, MaxCpuCoolerHeightMm = 167, FanMountCount = 10, SidePanel = "Tempered Glass", ExternalVolumeLiters = 60.0m, Internal35Bays = 4, Price = 1999m }
        });

        AddIfEmpty(context, context.PowerSupplies, new[]
        {
            new PowerSupply { Name = "CV550", ManufacturerId = manufacturers["Corsair"].Id, Type = "ATX", EfficiencyRating = "80+ Bronze", Wattage = 550, Modular = "No", Price = 699m },
            new PowerSupply { Name = "RM750e", ManufacturerId = manufacturers["Corsair"].Id, Type = "ATX", EfficiencyRating = "80+ Gold", Wattage = 750, Modular = "Full", Price = 1399m },
            new PowerSupply { Name = "Straight Power 12 850W", ManufacturerId = manufacturers["be quiet!"].Id, Type = "ATX", EfficiencyRating = "80+ Platinum", Wattage = 850, Modular = "Full", Price = 1899m },
            new PowerSupply { Name = "SuperNOVA 1000 G7", ManufacturerId = manufacturers["EVGA"].Id, Type = "ATX", EfficiencyRating = "80+ Gold", Wattage = 1000, Modular = "Full", Price = 2299m },
            new PowerSupply { Name = "Toughpower GF3 1200W", ManufacturerId = manufacturers["Thermaltake"].Id, Type = "ATX", EfficiencyRating = "80+ Gold", Wattage = 1200, Modular = "Full", Price = 2699m },
            new PowerSupply { Name = "CX650M", ManufacturerId = manufacturers["Corsair"].Id, Type = "ATX", EfficiencyRating = "80+ Bronze", Wattage = 650, Modular = "Semi", Price = 899m },
            new PowerSupply { Name = "RM850x", ManufacturerId = manufacturers["Corsair"].Id, Type = "ATX", EfficiencyRating = "80+ Gold", Wattage = 850, Modular = "Full", Price = 1699m },
            new PowerSupply { Name = "Pure Power 12 M 750W", ManufacturerId = manufacturers["be quiet!"].Id, Type = "ATX", EfficiencyRating = "80+ Gold", Wattage = 750, Modular = "Full", Price = 1499m },
            new PowerSupply { Name = "Focus GX-750", ManufacturerId = manufacturers["Seasonic"].Id, Type = "ATX", EfficiencyRating = "80+ Gold", Wattage = 750, Modular = "Full", Price = 1499m },
            new PowerSupply { Name = "Focus GX-850", ManufacturerId = manufacturers["Seasonic"].Id, Type = "ATX", EfficiencyRating = "80+ Gold", Wattage = 850, Modular = "Full", Price = 1799m },
            new PowerSupply { Name = "ROG Loki 850W SFX-L", ManufacturerId = manufacturers["ASUS"].Id, Type = "SFX-L", EfficiencyRating = "80+ Platinum", Wattage = 850, Modular = "Full", Price = 2499m }
        });

        AddIfEmpty(context, context.CpuCoolers, new[]
        {
            new CpuCooler { Name = "Pure Rock 2", ManufacturerId = manufacturers["be quiet!"].Id, IsAio = false, MaxTdpWatts = 150, HeightMm = 155, RpmMin = 300, RpmMax = 1500, Price = 499m },
            new CpuCooler { Name = "Kraken 240", ManufacturerId = manufacturers["NZXT"].Id, IsAio = true, RadiatorSize = 240, MaxTdpWatts = 220, RpmMin = 500, RpmMax = 1800, Price = 1699m },
            new CpuCooler { Name = "Dark Rock Pro 5", ManufacturerId = manufacturers["be quiet!"].Id, IsAio = false, MaxTdpWatts = 270, HeightMm = 168, RpmMin = 300, RpmMax = 2000, Price = 1199m },
            new CpuCooler { Name = "H100i Elite", ManufacturerId = manufacturers["Corsair"].Id, IsAio = true, RadiatorSize = 240, MaxTdpWatts = 250, RpmMin = 400, RpmMax = 2400, Price = 1799m },
            new CpuCooler { Name = "Kraken Elite 360", ManufacturerId = manufacturers["NZXT"].Id, IsAio = true, RadiatorSize = 360, MaxTdpWatts = 300, RpmMin = 500, RpmMax = 1800, Price = 2999m },
            new CpuCooler { Name = "Hyper 212 Black", ManufacturerId = manufacturers["Cooler Master"].Id, IsAio = false, MaxTdpWatts = 150, HeightMm = 159, RpmMin = 650, RpmMax = 2000, Price = 449m },
            new CpuCooler { Name = "Peerless Assassin 120 SE", ManufacturerId = manufacturers["Thermalright"].Id, IsAio = false, MaxTdpWatts = 265, HeightMm = 155, RpmMin = 300, RpmMax = 1550, Price = 499m },
            new CpuCooler { Name = "NH-D15", ManufacturerId = manufacturers["Noctua"].Id, IsAio = false, MaxTdpWatts = 250, HeightMm = 165, RpmMin = 300, RpmMax = 1500, Price = 1299m },
            new CpuCooler { Name = "AK620", ManufacturerId = manufacturers["DeepCool"].Id, IsAio = false, MaxTdpWatts = 260, HeightMm = 160, RpmMin = 500, RpmMax = 1850, Price = 799m },
            new CpuCooler { Name = "Liquid Freezer III 280", ManufacturerId = manufacturers["Arctic"].Id, IsAio = true, RadiatorSize = 280, MaxTdpWatts = 300, RpmMin = 200, RpmMax = 1700, Price = 1299m },
            new CpuCooler { Name = "iCUE H150i Elite", ManufacturerId = manufacturers["Corsair"].Id, IsAio = true, RadiatorSize = 360, MaxTdpWatts = 320, RpmMin = 400, RpmMax = 2400, Price = 2599m }
        });

        AddIfEmpty(context, context.CaseFans, new[]
        {
            new CaseFan { Name = "P12 PWM", ManufacturerId = manufacturers["Arctic"].Id, SizeMM = 120, RpmMin = 200, RpmMax = 1800, Pwm = true, Price = 99m },
            new CaseFan { Name = "LL120 RGB", ManufacturerId = manufacturers["Corsair"].Id, SizeMM = 120, RpmMin = 600, RpmMax = 1500, Pwm = true, Price = 299m },
            new CaseFan { Name = "Silent Wings 4", ManufacturerId = manufacturers["be quiet!"].Id, SizeMM = 140, RpmMin = 300, RpmMax = 1100, Pwm = true, Price = 269m },
            new CaseFan { Name = "P14 PWM", ManufacturerId = manufacturers["Arctic"].Id, SizeMM = 140, RpmMin = 200, RpmMax = 1700, Pwm = true, Price = 129m },
            new CaseFan { Name = "NF-A12x25 PWM", ManufacturerId = manufacturers["Noctua"].Id, SizeMM = 120, RpmMin = 450, RpmMax = 2000, Pwm = true, Price = 349m },
            new CaseFan { Name = "Uni Fan SL120 V2", ManufacturerId = manufacturers["Lian Li"].Id, SizeMM = 120, RpmMin = 250, RpmMax = 2000, Pwm = true, Price = 329m },
            new CaseFan { Name = "F120 RGB", ManufacturerId = manufacturers["NZXT"].Id, SizeMM = 120, RpmMin = 500, RpmMax = 1800, Pwm = true, Price = 249m }
        });

        AddIfEmpty(context, context.InternalHardDrives, new[]
        {
            new InternalHardDrive { Name = "970 EVO Plus 1TB", ManufacturerId = manufacturers["Samsung"].Id, CapacityGB = 1000, Type = "SSD", FormFactor = "M.2", Interface = "NVMe", Price = 899m },
            new InternalHardDrive { Name = "980 PRO 2TB", ManufacturerId = manufacturers["Samsung"].Id, CapacityGB = 2000, Type = "SSD", FormFactor = "M.2", Interface = "NVMe", Price = 1599m },
            new InternalHardDrive { Name = "Barracuda 4TB", ManufacturerId = manufacturers["Seagate"].Id, CapacityGB = 4000, Type = "HDD", FormFactor = "3.5", Interface = "SATA", CacheMB = 256, Price = 999m },
            new InternalHardDrive { Name = "990 PRO 1TB", ManufacturerId = manufacturers["Samsung"].Id, CapacityGB = 1000, Type = "SSD", FormFactor = "M.2", Interface = "NVMe", Price = 1199m },
            new InternalHardDrive { Name = "990 PRO 2TB", ManufacturerId = manufacturers["Samsung"].Id, CapacityGB = 2000, Type = "SSD", FormFactor = "M.2", Interface = "NVMe", Price = 1999m },
            new InternalHardDrive { Name = "SN850X 2TB", ManufacturerId = manufacturers["Western Digital"].Id, CapacityGB = 2000, Type = "SSD", FormFactor = "M.2", Interface = "NVMe", Price = 1799m },
            new InternalHardDrive { Name = "Crucial P3 Plus 2TB", ManufacturerId = manufacturers["Crucial"].Id, CapacityGB = 2000, Type = "SSD", FormFactor = "M.2", Interface = "NVMe", Price = 1399m },
            new InternalHardDrive { Name = "MX500 1TB", ManufacturerId = manufacturers["Crucial"].Id, CapacityGB = 1000, Type = "SSD", FormFactor = "2.5", Interface = "SATA", Price = 899m },
            new InternalHardDrive { Name = "IronWolf 8TB", ManufacturerId = manufacturers["Seagate"].Id, CapacityGB = 8000, Type = "HDD", FormFactor = "3.5", Interface = "SATA", CacheMB = 256, Price = 2299m },
            new InternalHardDrive { Name = "WD Blue 2TB", ManufacturerId = manufacturers["Western Digital"].Id, CapacityGB = 2000, Type = "HDD", FormFactor = "3.5", Interface = "SATA", CacheMB = 256, Price = 799m }
        });

        AddIfEmpty(context, context.ExternalHardDrives, new[]
        {
            new ExternalHardDrive { Name = "Elements Portable 2TB", ManufacturerId = manufacturers["Western Digital"].Id, CapacityGB = 2000, Type = "HDD", Interface = "USB 3.0", Price = 899m },
            new ExternalHardDrive { Name = "T7 Shield 1TB", ManufacturerId = manufacturers["Samsung"].Id, CapacityGB = 1000, Type = "SSD", Interface = "USB-C", Price = 1199m },
            new ExternalHardDrive { Name = "T7 Shield 2TB", ManufacturerId = manufacturers["Samsung"].Id, CapacityGB = 2000, Type = "SSD", Interface = "USB-C", Price = 1999m },
            new ExternalHardDrive { Name = "My Passport 4TB", ManufacturerId = manufacturers["Western Digital"].Id, CapacityGB = 4000, Type = "HDD", Interface = "USB 3.0", Price = 1299m },
            new ExternalHardDrive { Name = "Expansion Desktop 8TB", ManufacturerId = manufacturers["Seagate"].Id, CapacityGB = 8000, Type = "HDD", Interface = "USB 3.0", Price = 2199m }
        });

        AddIfEmpty(context, context.Monitors, new[]
        {
            new Monitor { Name = "24G2SPU", ManufacturerId = manufacturers["AOC"].Id, ScreenSizeInches = 24, ResolutionWidth = 1920, ResolutionHeight = 1080, RefreshRateHz = 165, ResponseTimeMs = 1, PanelType = "IPS", AspectRatio = "16:9", Price = 1999m },
            new Monitor { Name = "Odyssey G5 27", ManufacturerId = manufacturers["Samsung"].Id, ScreenSizeInches = 27, ResolutionWidth = 2560, ResolutionHeight = 1440, RefreshRateHz = 144, ResponseTimeMs = 1, PanelType = "VA", AspectRatio = "16:9", Price = 2999m },
            new Monitor { Name = "Alienware AW3423DWF", ManufacturerId = manufacturers["Dell"].Id, ScreenSizeInches = 34, ResolutionWidth = 3440, ResolutionHeight = 1440, RefreshRateHz = 165, ResponseTimeMs = 0.1m, PanelType = "OLED", AspectRatio = "21:9", Price = 10999m },
            new Monitor { Name = "VG249Q1A", ManufacturerId = manufacturers["ASUS"].Id, ScreenSizeInches = 24, ResolutionWidth = 1920, ResolutionHeight = 1080, RefreshRateHz = 165, ResponseTimeMs = 1, PanelType = "IPS", AspectRatio = "16:9", Price = 1799m },
            new Monitor { Name = "M27Q", ManufacturerId = manufacturers["Gigabyte"].Id, ScreenSizeInches = 27, ResolutionWidth = 2560, ResolutionHeight = 1440, RefreshRateHz = 170, ResponseTimeMs = 1, PanelType = "IPS", AspectRatio = "16:9", Price = 3499m },
            new Monitor { Name = "Odyssey G7 32", ManufacturerId = manufacturers["Samsung"].Id, ScreenSizeInches = 32, ResolutionWidth = 2560, ResolutionHeight = 1440, RefreshRateHz = 240, ResponseTimeMs = 1, PanelType = "VA", AspectRatio = "16:9", Price = 5999m },
            new Monitor { Name = "UltraGear 27GP850", ManufacturerId = manufacturers["LG"].Id, ScreenSizeInches = 27, ResolutionWidth = 2560, ResolutionHeight = 1440, RefreshRateHz = 180, ResponseTimeMs = 1, PanelType = "Nano IPS", AspectRatio = "16:9", Price = 3999m },
            new Monitor { Name = "TUF Gaming VG28UQL1A", ManufacturerId = manufacturers["ASUS"].Id, ScreenSizeInches = 28, ResolutionWidth = 3840, ResolutionHeight = 2160, RefreshRateHz = 144, ResponseTimeMs = 1, PanelType = "IPS", AspectRatio = "16:9", Price = 6999m },
            new Monitor { Name = "U2723QE", ManufacturerId = manufacturers["Dell"].Id, ScreenSizeInches = 27, ResolutionWidth = 3840, ResolutionHeight = 2160, RefreshRateHz = 60, ResponseTimeMs = 5, PanelType = "IPS Black", AspectRatio = "16:9", Price = 6999m }
        });

        AddIfEmpty(context, context.Keyboards, new[]
        {
            new Keyboard { Name = "K70 RGB", ManufacturerId = manufacturers["Corsair"].Id, Style = "Gaming", Switches = "Cherry MX Red", Backlit = "RGB", Tenkeyless = false, Connection = "USB", Price = 1499m },
            new Keyboard { Name = "Apex Pro TKL", ManufacturerId = manufacturers["SteelSeries"].Id, Style = "Gaming", Switches = "OmniPoint", Backlit = "RGB", Tenkeyless = true, Connection = "USB", Price = 2199m },
            new Keyboard { Name = "G Pro X TKL", ManufacturerId = manufacturers["Logitech"].Id, Style = "Gaming", Switches = "GX Brown", Backlit = "RGB", Tenkeyless = true, Connection = "Wireless", Price = 1999m },
            new Keyboard { Name = "Huntsman V2 TKL", ManufacturerId = manufacturers["Razer"].Id, Style = "Gaming", Switches = "Optical Red", Backlit = "RGB", Tenkeyless = true, Connection = "USB", Price = 1599m },
            new Keyboard { Name = "MX Keys S", ManufacturerId = manufacturers["Logitech"].Id, Style = "Office", Switches = "Scissor", Backlit = "White", Tenkeyless = false, Connection = "Wireless", Price = 1299m }
        });

        AddIfEmpty(context, context.Mice, new[]
        {
            new Mouse { Name = "G502 X", ManufacturerId = manufacturers["Logitech"].Id, TrackingMethod = "Optical", Connection = "USB", MaxDpi = 25600, HandOrientation = "Right", Price = 799m },
            new Mouse { Name = "DeathAdder V3", ManufacturerId = manufacturers["Razer"].Id, TrackingMethod = "Optical", Connection = "USB", MaxDpi = 30000, HandOrientation = "Right", Price = 899m },
            new Mouse { Name = "G Pro X Superlight", ManufacturerId = manufacturers["Logitech"].Id, TrackingMethod = "Optical", Connection = "Wireless", MaxDpi = 25600, HandOrientation = "Right", Price = 1499m },
            new Mouse { Name = "Viper V2 Pro", ManufacturerId = manufacturers["Razer"].Id, TrackingMethod = "Optical", Connection = "Wireless", MaxDpi = 30000, HandOrientation = "Ambidextrous", Price = 1499m },
            new Mouse { Name = "Aerox 3 Wireless", ManufacturerId = manufacturers["SteelSeries"].Id, TrackingMethod = "Optical", Connection = "Wireless", MaxDpi = 18000, HandOrientation = "Right", Price = 999m }
        });

        AddIfEmpty(context, context.Headphones, new[]
        {
            new Headphones { Name = "Arctis Nova 7", ManufacturerId = manufacturers["SteelSeries"].Id, Type = "Headset", Microphone = true, Wireless = true, EnclosureType = "Closed", Price = 1899m },
            new Headphones { Name = "BlackShark V2", ManufacturerId = manufacturers["Razer"].Id, Type = "Headset", Microphone = true, Wireless = false, EnclosureType = "Closed", Price = 999m },
            new Headphones { Name = "Cloud III Wireless", ManufacturerId = manufacturers["HyperX"].Id, Type = "Headset", Microphone = true, Wireless = true, EnclosureType = "Closed", Price = 1699m },
            new Headphones { Name = "G Pro X 2 Lightspeed", ManufacturerId = manufacturers["Logitech"].Id, Type = "Headset", Microphone = true, Wireless = true, EnclosureType = "Closed", Price = 2499m },
            new Headphones { Name = "HD 560S", ManufacturerId = manufacturers["Sennheiser"].Id, Type = "Headphones", Microphone = false, Wireless = false, EnclosureType = "Open", Price = 1899m }
        });

        AddIfEmpty(context, context.Speakers, new[]
        {
            new Speakers { Name = "Pebble V3", ManufacturerId = manufacturers["Creative"].Id, Configuration = "2.0", Wattage = 8, FrequencyMinHz = 100, FrequencyMaxKhz = 17, Price = 449m },
            new Speakers { Name = "Z407", ManufacturerId = manufacturers["Logitech"].Id, Configuration = "2.1", Wattage = 80, FrequencyMinHz = 40, FrequencyMaxKhz = 20, Price = 1199m },
            new Speakers { Name = "G560 Lightsync", ManufacturerId = manufacturers["Logitech"].Id, Configuration = "2.1", Wattage = 120, FrequencyMinHz = 40, FrequencyMaxKhz = 18, Price = 2499m },
            new Speakers { Name = "Companion 2 Series III", ManufacturerId = manufacturers["Bose"].Id, Configuration = "2.0", Wattage = 20, FrequencyMinHz = 70, FrequencyMaxKhz = 20, Price = 1299m },
            new Speakers { Name = "R1280DB", ManufacturerId = manufacturers["Edifier"].Id, Configuration = "2.0", Wattage = 42, FrequencyMinHz = 55, FrequencyMaxKhz = 20, Price = 1199m }
        });

        AddIfEmpty(context, context.Webcams, new[]
        {
            new Webcam { Name = "C920s", ManufacturerId = manufacturers["Logitech"].Id, Resolutions = "1080p", Connection = "USB", FocusType = "Autofocus", FovDegrees = 78, Price = 899m },
            new Webcam { Name = "Kiyo Pro", ManufacturerId = manufacturers["Razer"].Id, Resolutions = "1080p", Connection = "USB", FocusType = "Autofocus", FovDegrees = 103, Price = 1899m },
            new Webcam { Name = "Brio 4K", ManufacturerId = manufacturers["Logitech"].Id, Resolutions = "4K", Connection = "USB-C", FocusType = "Autofocus", FovDegrees = 90, Price = 2199m },
            new Webcam { Name = "Facecam", ManufacturerId = manufacturers["Elgato"].Id, Resolutions = "1080p", Connection = "USB-C", FocusType = "Fixed", FovDegrees = 82, Price = 1699m },
            new Webcam { Name = "StreamCam", ManufacturerId = manufacturers["Logitech"].Id, Resolutions = "1080p", Connection = "USB-C", FocusType = "Autofocus", FovDegrees = 78, Price = 1499m }
        });

        AddIfEmpty(context, context.FanControllers, new[]
        {
            new FanController { Name = "Commander Core XT", ManufacturerId = manufacturers["Corsair"].Id, Channels = 6, ChannelWattage = 12, Pwm = true, FormFactor = "Internal", Price = 699m },
            new FanController { Name = "Grid+ V3", ManufacturerId = manufacturers["NZXT"].Id, Channels = 6, ChannelWattage = 10, Pwm = true, FormFactor = "Internal", Price = 499m },
            new FanController { Name = "Commander Pro", ManufacturerId = manufacturers["Corsair"].Id, Channels = 6, ChannelWattage = 12, Pwm = true, FormFactor = "Internal", Price = 799m },
            new FanController { Name = "FH-10", ManufacturerId = manufacturers["DeepCool"].Id, Channels = 10, ChannelWattage = 10, Pwm = true, FormFactor = "Internal", Price = 199m },
            new FanController { Name = "NA-FC1", ManufacturerId = manufacturers["Noctua"].Id, Channels = 3, ChannelWattage = 10, Pwm = true, FormFactor = "Internal", Price = 249m }
        });

        AddIfEmpty(context, context.SoundCards, new[]
        {
            new SoundCard { Name = "Sound Blaster Z SE", ManufacturerId = manufacturers["Creative"].Id, Channels = "5.1", DigitalAudioBits = 24, SnrDb = 116, SampleRateKhz = 192, Interface = "PCIe", Price = 1099m },
            new SoundCard { Name = "Sound Blaster Audigy FX", ManufacturerId = manufacturers["Creative"].Id, Channels = "5.1", DigitalAudioBits = 24, SnrDb = 106, SampleRateKhz = 192, Interface = "PCIe", Price = 549m },
            new SoundCard { Name = "Sound BlasterX AE-5 Plus", ManufacturerId = manufacturers["Creative"].Id, Channels = "5.1", DigitalAudioBits = 32, SnrDb = 122, SampleRateKhz = 384, Interface = "PCIe", Price = 1599m },
            new SoundCard { Name = "Xonar SE", ManufacturerId = manufacturers["ASUS"].Id, Channels = "5.1", DigitalAudioBits = 24, SnrDb = 116, SampleRateKhz = 192, Interface = "PCIe", Price = 599m }
        });

        AddIfEmpty(context, context.UpsSystems, new[]
        {
            new Ups { Name = "Back-UPS 700VA", ManufacturerId = manufacturers["APC"].Id, CapacityVa = 700, CapacityWatts = 390, Price = 1299m },
            new Ups { Name = "UPS 1000VA", ManufacturerId = manufacturers["CyberPower"].Id, CapacityVa = 1000, CapacityWatts = 600, Price = 1899m },
            new Ups { Name = "Back-UPS Pro 900VA", ManufacturerId = manufacturers["APC"].Id, CapacityVa = 900, CapacityWatts = 540, Price = 2499m },
            new Ups { Name = "CP1500EPFCLCD", ManufacturerId = manufacturers["CyberPower"].Id, CapacityVa = 1500, CapacityWatts = 900, Price = 3499m }
        });

        AddIfEmpty(context, context.OperatingSystems, new[]
        {
            new OperatingSystem { Name = "Windows 11 Home", ManufacturerId = manufacturers["Microsoft"].Id, Architecture = "64-bit", MaxMemoryGB = 128, Price = 1499m },
            new OperatingSystem { Name = "Windows 11 Pro", ManufacturerId = manufacturers["Microsoft"].Id, Architecture = "64-bit", MaxMemoryGB = 2000, Price = 2499m },
            new OperatingSystem { Name = "Windows 10 Home", ManufacturerId = manufacturers["Microsoft"].Id, Architecture = "64-bit", MaxMemoryGB = 128, Price = 1199m },
            new OperatingSystem { Name = "Windows 10 Pro", ManufacturerId = manufacturers["Microsoft"].Id, Architecture = "64-bit", MaxMemoryGB = 2000, Price = 1999m }
        });

        AddIfEmpty(context, context.CaseAccessories, new[]
        {
            new CaseAccessory { Name = "Vertical GPU Mount", ManufacturerId = manufacturers["Thermaltake"].Id, Type = "Mount", FormFactor = "PCIe", Price = 599m },
            new CaseAccessory { Name = "HDD Tray Kit", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Drive tray", FormFactor = "3.5", Price = 199m },
            new CaseAccessory { Name = "PCIe 4.0 Riser Cable", ManufacturerId = manufacturers["Lian Li"].Id, Type = "Cable", FormFactor = "PCIe", Price = 699m },
            new CaseAccessory { Name = "ARGB Lighting Strip", ManufacturerId = manufacturers["Corsair"].Id, Type = "Lighting", FormFactor = "Internal", Price = 299m },
            new CaseAccessory { Name = "Dust Filter Kit", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Filter", FormFactor = "Case", Price = 149m }
        });

        SeedStarterComponents(context, manufacturers, formFactors);
        BalanceStarterPrices(context);
    }

    private static void SeedStarterComponents(
        DataContext context,
        Dictionary<string, Manufacturer> manufacturers,
        Dictionary<string, FormFactor> formFactors)
    {
        AddMissingByName(context.Cpus, new[]
        {
            new Cpu { Name = "Pentium Gold G7400", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 2, CoreClock = 3.7m, BoostClock = 3.7m, Microarchitecture = "Alder Lake", Tdp = 46, IntegratedGraphics = "UHD 710", Price = 549m },
            new Cpu { Name = "Core i3-10105F", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 4, CoreClock = 3.7m, BoostClock = 4.4m, Microarchitecture = "Comet Lake", Tdp = 65, IntegratedGraphics = "No", Price = 699m },
            new Cpu { Name = "Ryzen 3 4100", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 4, CoreClock = 3.8m, BoostClock = 4.0m, Microarchitecture = "Zen 2", Tdp = 65, IntegratedGraphics = "No", Price = 649m },
            new Cpu { Name = "Ryzen 5 4500", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 6, CoreClock = 3.6m, BoostClock = 4.1m, Microarchitecture = "Zen 2", Tdp = 65, IntegratedGraphics = "No", Price = 899m }
        }, x => x.Name);

        AddMissingByName(context.VideoCards, new[]
        {
            new VideoCard { Name = "GeForce GTX 1050 Ti", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 75, Chipset = "GP107", MemoryGB = 4, CoreClock = 1290, BoostClock = 1392, LengthMM = 145, Price = 999m },
            new VideoCard { Name = "GeForce GTX 1650", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 75, Chipset = "TU117", MemoryGB = 4, CoreClock = 1485, BoostClock = 1665, LengthMM = 170, Price = 1499m },
            new VideoCard { Name = "Radeon RX 6400", ManufacturerId = manufacturers["AMD"].Id, Tdp = 53, Chipset = "Navi 24", MemoryGB = 4, CoreClock = 1923, BoostClock = 2321, LengthMM = 170, Price = 1199m },
            new VideoCard { Name = "Radeon RX 6500 XT", ManufacturerId = manufacturers["AMD"].Id, Tdp = 107, Chipset = "Navi 24", MemoryGB = 4, CoreClock = 2310, BoostClock = 2815, LengthMM = 190, Price = 1599m },
            new VideoCard { Name = "Arc A380", ManufacturerId = manufacturers["Intel"].Id, Tdp = 75, Chipset = "Alchemist", MemoryGB = 6, CoreClock = 2000, BoostClock = 2450, LengthMM = 190, Price = 1399m }
        }, x => x.Name);

        AddMissingByName(context.MemoryKits, new[]
        {
            new MemoryKit { Name = "ValueRAM 8GB", TotalCapacityGB = 8, ManufacturerId = manufacturers["Kingston"].Id, ModulesCount = 1, SpeedMTs = 2666, CasLatency = 19, FirstWordLatency = 14.2m, Price = 299m },
            new MemoryKit { Name = "ValueRAM 16GB", TotalCapacityGB = 16, ManufacturerId = manufacturers["Kingston"].Id, ModulesCount = 2, SpeedMTs = 3200, CasLatency = 22, FirstWordLatency = 13.8m, Price = 449m },
            new MemoryKit { Name = "TeamGroup Elite 16GB", TotalCapacityGB = 16, ManufacturerId = manufacturers["TeamGroup"].Id, ModulesCount = 2, SpeedMTs = 3200, CasLatency = 22, FirstWordLatency = 13.8m, Price = 429m }
        }, x => x.Name);

        AddMissingByName(context.Motherboards, new[]
        {
            new Motherboard { Name = "PRIME H610M-K", ManufacturerId = manufacturers["ASUS"].Id, Socket = "LGA1700", FormFactorId = formFactors["Micro-ATX"].Id, MaxMemoryGB = 64, MemorySlots = 2, HasWiFi = false, Price = 899m },
            new Motherboard { Name = "A520M-A PRO", ManufacturerId = manufacturers["MSI"].Id, Socket = "AM4", FormFactorId = formFactors["Micro-ATX"].Id, MaxMemoryGB = 64, MemorySlots = 2, HasWiFi = false, Price = 799m },
            new Motherboard { Name = "B450M DS3H", ManufacturerId = manufacturers["Gigabyte"].Id, Socket = "AM4", FormFactorId = formFactors["Micro-ATX"].Id, MaxMemoryGB = 128, MemorySlots = 4, HasWiFi = false, Price = 849m }
        }, x => x.Name);

        AddMissingByName(context.Cases, new[]
        {
            new Case { Name = "Versa H18", ManufacturerId = manufacturers["Thermaltake"].Id, Type = "Micro Tower", MaxGpuLengthMm = 350, MaxCpuCoolerHeightMm = 155, FanMountCount = 4, SidePanel = "Acrylic", ExternalVolumeLiters = 32.0m, Internal35Bays = 2, Price = 499m },
            new Case { Name = "Matrexx 40", ManufacturerId = manufacturers["DeepCool"].Id, Type = "Micro Tower", MaxGpuLengthMm = 320, MaxCpuCoolerHeightMm = 165, FanMountCount = 5, SidePanel = "Tempered Glass", ExternalVolumeLiters = 36.0m, Internal35Bays = 2, Price = 599m },
            new Case { Name = "Focus G Mini", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Mini Tower", MaxGpuLengthMm = 380, MaxCpuCoolerHeightMm = 165, FanMountCount = 6, SidePanel = "Acrylic", ExternalVolumeLiters = 38.0m, Internal35Bays = 2, Price = 649m }
        }, x => x.Name);

        AddMissingByName(context.PowerSupplies, new[]
        {
            new PowerSupply { Name = "System Power 10 450W", ManufacturerId = manufacturers["be quiet!"].Id, Type = "ATX", EfficiencyRating = "80+ Bronze", Wattage = 450, Modular = "No", Price = 399m },
            new PowerSupply { Name = "CV450", ManufacturerId = manufacturers["Corsair"].Id, Type = "ATX", EfficiencyRating = "80+ Bronze", Wattage = 450, Modular = "No", Price = 449m },
            new PowerSupply { Name = "MWE 500 Bronze", ManufacturerId = manufacturers["Cooler Master"].Id, Type = "ATX", EfficiencyRating = "80+ Bronze", Wattage = 500, Modular = "No", Price = 499m }
        }, x => x.Name);

        AddMissingByName(context.CpuCoolers, new[]
        {
            new CpuCooler { Name = "A30 Compact", ManufacturerId = manufacturers["Arctic"].Id, IsAio = false, MaxTdpWatts = 95, HeightMm = 137, RpmMin = 600, RpmMax = 2000, Price = 199m },
            new CpuCooler { Name = "AG200", ManufacturerId = manufacturers["DeepCool"].Id, IsAio = false, MaxTdpWatts = 100, HeightMm = 133, RpmMin = 500, RpmMax = 2400, Price = 249m }
        }, x => x.Name);

        AddMissingByName(context.InternalHardDrives, new[]
        {
            new InternalHardDrive { Name = "A400 480GB", ManufacturerId = manufacturers["Kingston"].Id, CapacityGB = 480, Type = "SSD", FormFactor = "2.5", Interface = "SATA", Price = 349m },
            new InternalHardDrive { Name = "NV2 500GB", ManufacturerId = manufacturers["Kingston"].Id, CapacityGB = 500, Type = "SSD", FormFactor = "M.2", Interface = "NVMe", Price = 449m },
            new InternalHardDrive { Name = "BX500 500GB", ManufacturerId = manufacturers["Crucial"].Id, CapacityGB = 500, Type = "SSD", FormFactor = "2.5", Interface = "SATA", Price = 329m }
        }, x => x.Name);

        AddMissingByName(context.CaseFans, new[]
        {
            new CaseFan { Name = "F12 Silent", ManufacturerId = manufacturers["Arctic"].Id, SizeMM = 120, RpmMin = 400, RpmMax = 1350, Pwm = false, Price = 79m }
        }, x => x.Name);

        AddMissingByName(context.Monitors, new[]
        {
            new Monitor { Name = "V24i G5", ManufacturerId = manufacturers["HP"].Id, ScreenSizeInches = 24, ResolutionWidth = 1920, ResolutionHeight = 1080, RefreshRateHz = 75, ResponseTimeMs = 5, PanelType = "IPS", AspectRatio = "16:9", Price = 1199m }
        }, x => x.Name);

        AddMissingByName(context.Keyboards, new[]
        {
            new Keyboard { Name = "K120", ManufacturerId = manufacturers["Logitech"].Id, Style = "Office", Switches = "Membrane", Backlit = "No", Tenkeyless = false, Connection = "USB", Price = 149m }
        }, x => x.Name);

        AddMissingByName(context.Mice, new[]
        {
            new Mouse { Name = "M90", ManufacturerId = manufacturers["Logitech"].Id, TrackingMethod = "Optical", Connection = "USB", MaxDpi = 1000, HandOrientation = "Ambidextrous", Price = 99m }
        }, x => x.Name);

        context.SaveChanges();
    }

    private static void BalanceStarterPrices(DataContext context)
    {
        SetPrice(context.Cpus, "Core i3-12100F", 799m);
        SetPrice(context.Cpus, "Ryzen 5 5600", 1099m);
        SetPrice(context.Cpus, "Core i3-14100F", 999m);
        SetPrice(context.VideoCards, "GeForce GTX 1660 Super", 1799m);
        SetPrice(context.VideoCards, "Radeon RX 6600", 1999m);
        SetPrice(context.VideoCards, "Radeon RX 6650 XT", 2399m);
        SetPrice(context.MemoryKits, "FURY Beast 16GB", 499m);
        SetPrice(context.MemoryKits, "Vengeance LPX 16GB", 549m);
        SetPrice(context.Motherboards, "B550 AORUS ELITE V2", 1199m);
        SetPrice(context.Motherboards, "TUF GAMING B550-PLUS", 1299m);
        SetPrice(context.Cases, "H510 Flow", 799m);
        SetPrice(context.Cases, "Pop Mini Air", 899m);
        SetPrice(context.PowerSupplies, "CV550", 549m);
        SetPrice(context.PowerSupplies, "CX650M", 699m);
        SetPrice(context.CpuCoolers, "Hyper 212 Black", 349m);
        SetPrice(context.CpuCoolers, "Peerless Assassin 120 SE", 399m);
        SetPrice(context.InternalHardDrives, "970 EVO Plus 1TB", 699m);
        SetPrice(context.InternalHardDrives, "WD Blue 2TB", 649m);
        SetPrice(context.CaseFans, "P12 PWM", 79m);
        context.SaveChanges();
    }

    private static void SeedLookups(DataContext context)
    {
        var manufacturerNames = new[]
        {
            "Intel", "AMD", "NVIDIA", "Corsair", "ASUS", "MSI", "Gigabyte", "Kingston",
            "Seagate", "Western Digital", "Samsung", "Logitech", "SteelSeries", "NZXT",
            "be quiet!", "AOC", "Razer", "Creative", "EVGA", "Thermaltake", "Fractal Design",
            "Philips", "Dell", "HP", "Lenovo", "Arctic", "APC", "CyberPower", "Microsoft",
            "G.Skill", "TeamGroup", "ADATA", "Lian Li", "Seasonic", "Cooler Master", "Thermalright",
            "Noctua", "DeepCool", "Crucial", "LG", "HyperX", "Sennheiser", "Bose", "Edifier", "Elgato"
        };

        foreach (var name in manufacturerNames)
        {
            if (!context.Manufacturers.Any(x => x.Name == name))
            {
                context.Manufacturers.Add(new Manufacturer { Name = name });
            }
        }

        var formFactorNames = new[] { "ATX", "Micro-ATX", "Mini-ITX", "E-ATX", "XL-ATX" };
        foreach (var name in formFactorNames)
        {
            if (!context.FormFactors.Any(x => x.Name == name))
            {
                context.FormFactors.Add(new FormFactor { Name = name });
            }
        }

        context.SaveChanges();
    }

    private static void AddIfEmpty<TEntity>(DataContext context, DbSet<TEntity> dbSet, IEnumerable<TEntity> entities)
        where TEntity : class
    {
        if (dbSet.Any())
        {
            return;
        }

        dbSet.AddRange(entities);
        context.SaveChanges();
    }

    private static void AddMissingByName<TEntity>(DbSet<TEntity> dbSet, IEnumerable<TEntity> entities, Func<TEntity, string> getName)
        where TEntity : class
    {
        var existingNames = dbSet
            .AsEnumerable()
            .Select(getName)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var missing = entities
            .Where(entity => !existingNames.Contains(getName(entity)))
            .ToList();

        if (missing.Any())
        {
            dbSet.AddRange(missing);
        }
    }

    private static void SetPrice<TEntity>(DbSet<TEntity> dbSet, string name, decimal price)
        where TEntity : class
    {
        var entity = dbSet.FirstOrDefault(x => EF.Property<string>(x, "Name") == name);
        if (entity == null)
        {
            return;
        }

        var priceProperty = typeof(TEntity).GetProperty("Price");
        if (priceProperty == null)
        {
            return;
        }

        priceProperty.SetValue(entity, price);
    }
}
