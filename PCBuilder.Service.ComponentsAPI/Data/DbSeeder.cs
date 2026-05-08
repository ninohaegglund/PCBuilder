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
            new Cpu { Name = "Core i3-14100F", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 4, CoreClock = 3.5m, BoostClock = 4.7m, Microarchitecture = "Raptor Lake", Tdp = 58, IntegratedGraphics = "No", Price = 1299m },
            new Cpu { Name = "Ryzen 5 7600", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 6, CoreClock = 3.8m, BoostClock = 5.1m, Microarchitecture = "Zen 4", Tdp = 65, IntegratedGraphics = "Radeon Graphics", Price = 2499m },
            new Cpu { Name = "Core i5-14600K", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 14, CoreClock = 3.5m, BoostClock = 5.3m, Microarchitecture = "Raptor Lake Refresh", Tdp = 125, IntegratedGraphics = "UHD 770", Price = 3799m },
            new Cpu { Name = "Ryzen 7 7800X3D", ManufacturerId = manufacturers["AMD"].Id, CoreCount = 8, CoreClock = 4.2m, BoostClock = 5.0m, Microarchitecture = "Zen 4", Tdp = 120, IntegratedGraphics = "Radeon Graphics", Price = 4899m },
            new Cpu { Name = "Core i9-14900KS", ManufacturerId = manufacturers["Intel"].Id, CoreCount = 24, CoreClock = 3.2m, BoostClock = 6.2m, Microarchitecture = "Raptor Lake Refresh", Tdp = 150, IntegratedGraphics = "UHD 770", Price = 7999m }
        });

        AddIfEmpty(context, context.VideoCards, new[]
        {
            new VideoCard { Name = "GeForce RTX 4060", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 115, Chipset = "AD107", MemoryGB = 8, CoreClock = 1830, BoostClock = 2460, LengthMM = 240, Price = 3999m },
            new VideoCard { Name = "Radeon RX 7600", ManufacturerId = manufacturers["AMD"].Id, Tdp = 165, Chipset = "Navi 33", MemoryGB = 8, CoreClock = 1720, BoostClock = 2655, LengthMM = 244, Price = 3299m },
            new VideoCard { Name = "GeForce RTX 4070 Super", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 220, Chipset = "AD104", MemoryGB = 12, CoreClock = 1980, BoostClock = 2475, LengthMM = 267, Price = 6799m },
            new VideoCard { Name = "Radeon RX 7900 XTX", ManufacturerId = manufacturers["AMD"].Id, Tdp = 355, Chipset = "Navi 31", MemoryGB = 24, CoreClock = 1855, BoostClock = 2499, LengthMM = 287, Price = 11999m },
            new VideoCard { Name = "GeForce RTX 4090", ManufacturerId = manufacturers["NVIDIA"].Id, Tdp = 450, Chipset = "AD102", MemoryGB = 24, CoreClock = 2235, BoostClock = 2520, LengthMM = 304, Price = 18999m }
        });

        AddIfEmpty(context, context.MemoryKits, new[]
        {
            new MemoryKit { Name = "FURY Beast 16GB", TotalCapacityGB = 16, ManufacturerId = manufacturers["Kingston"].Id, ModulesCount = 2, SpeedMTs = 3200, CasLatency = 16, FirstWordLatency = 10.0m, Price = 599m },
            new MemoryKit { Name = "Vengeance LPX 16GB", TotalCapacityGB = 16, ManufacturerId = manufacturers["Corsair"].Id, ModulesCount = 2, SpeedMTs = 3600, CasLatency = 18, FirstWordLatency = 10.0m, Price = 699m },
            new MemoryKit { Name = "FURY Renegade 32GB", TotalCapacityGB = 32, ManufacturerId = manufacturers["Kingston"].Id, ModulesCount = 2, SpeedMTs = 6000, CasLatency = 30, FirstWordLatency = 10.0m, Price = 1499m },
            new MemoryKit { Name = "Vengeance RGB 32GB", TotalCapacityGB = 32, ManufacturerId = manufacturers["Corsair"].Id, ModulesCount = 2, SpeedMTs = 6400, CasLatency = 32, FirstWordLatency = 10.0m, Price = 1799m },
            new MemoryKit { Name = "Dominator Platinum 64GB", TotalCapacityGB = 64, ManufacturerId = manufacturers["Corsair"].Id, ModulesCount = 2, SpeedMTs = 6600, CasLatency = 32, FirstWordLatency = 10.0m, Price = 2999m }
        });

        AddIfEmpty(context, context.Motherboards, new[]
        {
            new Motherboard { Name = "PRIME B760M-A", ManufacturerId = manufacturers["ASUS"].Id, Socket = "LGA1700", FormFactorId = formFactors["Micro-ATX"].Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = false, Price = 1999m },
            new Motherboard { Name = "MAG B650 TOMAHAWK", ManufacturerId = manufacturers["MSI"].Id, Socket = "AM5", FormFactorId = formFactors["ATX"].Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = true, Price = 3199m },
            new Motherboard { Name = "ROG STRIX Z790-E", ManufacturerId = manufacturers["ASUS"].Id, Socket = "LGA1700", FormFactorId = formFactors["ATX"].Id, MaxMemoryGB = 192, MemorySlots = 4, HasWiFi = true, Price = 5499m },
            new Motherboard { Name = "X670E AORUS MASTER", ManufacturerId = manufacturers["Gigabyte"].Id, Socket = "AM5", FormFactorId = formFactors["E-ATX"].Id, MaxMemoryGB = 256, MemorySlots = 4, HasWiFi = true, Price = 6999m },
            new Motherboard { Name = "ROG CROSSHAIR X670E EXTREME", ManufacturerId = manufacturers["ASUS"].Id, Socket = "AM5", FormFactorId = formFactors["E-ATX"].Id, MaxMemoryGB = 256, MemorySlots = 4, HasWiFi = true, Price = 9999m }
        });

        AddIfEmpty(context, context.Cases, new[]
        {
            new Case { Name = "Pop Mini Air", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Mini Tower", MaxGpuLengthMm = 365, MaxCpuCoolerHeightMm = 170, FanMountCount = 5, SidePanel = "Tempered Glass", ExternalVolumeLiters = 37.0m, Internal35Bays = 2, Price = 1199m },
            new Case { Name = "H510 Flow", ManufacturerId = manufacturers["NZXT"].Id, Type = "Mid Tower", MaxGpuLengthMm = 360, MaxCpuCoolerHeightMm = 165, FanMountCount = 4, SidePanel = "Tempered Glass", ExternalVolumeLiters = 47.1m, Internal35Bays = 2, Price = 999m },
            new Case { Name = "Meshify 2 Compact", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Mid Tower", MaxGpuLengthMm = 341, MaxCpuCoolerHeightMm = 169, FanMountCount = 7, SidePanel = "Tempered Glass", ExternalVolumeLiters = 40.0m, Internal35Bays = 2, Price = 1499m },
            new Case { Name = "Define 7", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Mid Tower", MaxGpuLengthMm = 467, MaxCpuCoolerHeightMm = 185, FanMountCount = 9, SidePanel = "Solid", ExternalVolumeLiters = 45.5m, Internal35Bays = 6, Price = 1799m },
            new Case { Name = "View 51", ManufacturerId = manufacturers["Thermaltake"].Id, Type = "Full Tower", MaxGpuLengthMm = 440, MaxCpuCoolerHeightMm = 175, FanMountCount = 10, SidePanel = "Tempered Glass", ExternalVolumeLiters = 88.0m, Internal35Bays = 4, Price = 2299m }
        });

        AddIfEmpty(context, context.PowerSupplies, new[]
        {
            new PowerSupply { Name = "CV550", ManufacturerId = manufacturers["Corsair"].Id, Type = "ATX", EfficiencyRating = "80+ Bronze", Wattage = 550, Modular = "No", Price = 699m },
            new PowerSupply { Name = "RM750e", ManufacturerId = manufacturers["Corsair"].Id, Type = "ATX", EfficiencyRating = "80+ Gold", Wattage = 750, Modular = "Full", Price = 1399m },
            new PowerSupply { Name = "Straight Power 12 850W", ManufacturerId = manufacturers["be quiet!"].Id, Type = "ATX", EfficiencyRating = "80+ Platinum", Wattage = 850, Modular = "Full", Price = 1899m },
            new PowerSupply { Name = "SuperNOVA 1000 G7", ManufacturerId = manufacturers["EVGA"].Id, Type = "ATX", EfficiencyRating = "80+ Gold", Wattage = 1000, Modular = "Full", Price = 2299m },
            new PowerSupply { Name = "Toughpower GF3 1200W", ManufacturerId = manufacturers["Thermaltake"].Id, Type = "ATX", EfficiencyRating = "80+ Gold", Wattage = 1200, Modular = "Full", Price = 2699m }
        });

        AddIfEmpty(context, context.CpuCoolers, new[]
        {
            new CpuCooler { Name = "Pure Rock 2", ManufacturerId = manufacturers["be quiet!"].Id, IsAio = false, MaxTdpWatts = 150, HeightMm = 155, RpmMin = 300, RpmMax = 1500, Price = 499m },
            new CpuCooler { Name = "Kraken 240", ManufacturerId = manufacturers["NZXT"].Id, IsAio = true, RadiatorSize = 240, MaxTdpWatts = 220, RpmMin = 500, RpmMax = 1800, Price = 1699m },
            new CpuCooler { Name = "Dark Rock Pro 5", ManufacturerId = manufacturers["be quiet!"].Id, IsAio = false, MaxTdpWatts = 270, HeightMm = 168, RpmMin = 300, RpmMax = 2000, Price = 1199m },
            new CpuCooler { Name = "H100i Elite", ManufacturerId = manufacturers["Corsair"].Id, IsAio = true, RadiatorSize = 240, MaxTdpWatts = 250, RpmMin = 400, RpmMax = 2400, Price = 1799m },
            new CpuCooler { Name = "Kraken Elite 360", ManufacturerId = manufacturers["NZXT"].Id, IsAio = true, RadiatorSize = 360, MaxTdpWatts = 300, RpmMin = 500, RpmMax = 1800, Price = 2999m }
        });

        AddIfEmpty(context, context.CaseFans, new[]
        {
            new CaseFan { Name = "P12 PWM", ManufacturerId = manufacturers["Arctic"].Id, SizeMM = 120, RpmMin = 200, RpmMax = 1800, Pwm = true, Price = 99m },
            new CaseFan { Name = "LL120 RGB", ManufacturerId = manufacturers["Corsair"].Id, SizeMM = 120, RpmMin = 600, RpmMax = 1500, Pwm = true, Price = 299m },
            new CaseFan { Name = "Silent Wings 4", ManufacturerId = manufacturers["be quiet!"].Id, SizeMM = 140, RpmMin = 300, RpmMax = 1100, Pwm = true, Price = 269m }
        });

        AddIfEmpty(context, context.InternalHardDrives, new[]
        {
            new InternalHardDrive { Name = "970 EVO Plus 1TB", ManufacturerId = manufacturers["Samsung"].Id, CapacityGB = 1000, Type = "SSD", FormFactor = "M.2", Interface = "NVMe", Price = 899m },
            new InternalHardDrive { Name = "980 PRO 2TB", ManufacturerId = manufacturers["Samsung"].Id, CapacityGB = 2000, Type = "SSD", FormFactor = "M.2", Interface = "NVMe", Price = 1599m },
            new InternalHardDrive { Name = "Barracuda 4TB", ManufacturerId = manufacturers["Seagate"].Id, CapacityGB = 4000, Type = "HDD", FormFactor = "3.5", Interface = "SATA", CacheMB = 256, Price = 999m }
        });

        AddIfEmpty(context, context.ExternalHardDrives, new[]
        {
            new ExternalHardDrive { Name = "Elements Portable 2TB", ManufacturerId = manufacturers["Western Digital"].Id, CapacityGB = 2000, Type = "HDD", Interface = "USB 3.0", Price = 899m },
            new ExternalHardDrive { Name = "T7 Shield 1TB", ManufacturerId = manufacturers["Samsung"].Id, CapacityGB = 1000, Type = "SSD", Interface = "USB-C", Price = 1199m }
        });

        AddIfEmpty(context, context.Monitors, new[]
        {
            new Monitor { Name = "24G2SPU", ManufacturerId = manufacturers["AOC"].Id, ScreenSizeInches = 24, ResolutionWidth = 1920, ResolutionHeight = 1080, RefreshRateHz = 165, ResponseTimeMs = 1, PanelType = "IPS", AspectRatio = "16:9", Price = 1999m },
            new Monitor { Name = "Odyssey G5 27", ManufacturerId = manufacturers["Samsung"].Id, ScreenSizeInches = 27, ResolutionWidth = 2560, ResolutionHeight = 1440, RefreshRateHz = 144, ResponseTimeMs = 1, PanelType = "VA", AspectRatio = "16:9", Price = 2999m },
            new Monitor { Name = "Alienware AW3423DWF", ManufacturerId = manufacturers["Dell"].Id, ScreenSizeInches = 34, ResolutionWidth = 3440, ResolutionHeight = 1440, RefreshRateHz = 165, ResponseTimeMs = 0.1m, PanelType = "OLED", AspectRatio = "21:9", Price = 10999m }
        });

        AddIfEmpty(context, context.Keyboards, new[]
        {
            new Keyboard { Name = "K70 RGB", ManufacturerId = manufacturers["Corsair"].Id, Style = "Gaming", Switches = "Cherry MX Red", Backlit = "RGB", Tenkeyless = false, Connection = "USB", Price = 1499m },
            new Keyboard { Name = "Apex Pro TKL", ManufacturerId = manufacturers["SteelSeries"].Id, Style = "Gaming", Switches = "OmniPoint", Backlit = "RGB", Tenkeyless = true, Connection = "USB", Price = 2199m }
        });

        AddIfEmpty(context, context.Mice, new[]
        {
            new Mouse { Name = "G502 X", ManufacturerId = manufacturers["Logitech"].Id, TrackingMethod = "Optical", Connection = "USB", MaxDpi = 25600, HandOrientation = "Right", Price = 799m },
            new Mouse { Name = "DeathAdder V3", ManufacturerId = manufacturers["Razer"].Id, TrackingMethod = "Optical", Connection = "USB", MaxDpi = 30000, HandOrientation = "Right", Price = 899m }
        });

        AddIfEmpty(context, context.Headphones, new[]
        {
            new Headphones { Name = "Arctis Nova 7", ManufacturerId = manufacturers["SteelSeries"].Id, Type = "Headset", Microphone = true, Wireless = true, EnclosureType = "Closed", Price = 1899m },
            new Headphones { Name = "BlackShark V2", ManufacturerId = manufacturers["Razer"].Id, Type = "Headset", Microphone = true, Wireless = false, EnclosureType = "Closed", Price = 999m }
        });

        AddIfEmpty(context, context.Speakers, new[]
        {
            new Speakers { Name = "Pebble V3", ManufacturerId = manufacturers["Creative"].Id, Configuration = "2.0", Wattage = 8, FrequencyMinHz = 100, FrequencyMaxKhz = 17, Price = 449m },
            new Speakers { Name = "Z407", ManufacturerId = manufacturers["Logitech"].Id, Configuration = "2.1", Wattage = 80, FrequencyMinHz = 40, FrequencyMaxKhz = 20, Price = 1199m }
        });

        AddIfEmpty(context, context.Webcams, new[]
        {
            new Webcam { Name = "C920s", ManufacturerId = manufacturers["Logitech"].Id, Resolutions = "1080p", Connection = "USB", FocusType = "Autofocus", FovDegrees = 78, Price = 899m },
            new Webcam { Name = "Kiyo Pro", ManufacturerId = manufacturers["Razer"].Id, Resolutions = "1080p", Connection = "USB", FocusType = "Autofocus", FovDegrees = 103, Price = 1899m }
        });

        AddIfEmpty(context, context.FanControllers, new[]
        {
            new FanController { Name = "Commander Core XT", ManufacturerId = manufacturers["Corsair"].Id, Channels = 6, ChannelWattage = 12, Pwm = true, FormFactor = "Internal", Price = 699m },
            new FanController { Name = "Grid+ V3", ManufacturerId = manufacturers["NZXT"].Id, Channels = 6, ChannelWattage = 10, Pwm = true, FormFactor = "Internal", Price = 499m }
        });

        AddIfEmpty(context, context.SoundCards, new[]
        {
            new SoundCard { Name = "Sound Blaster Z SE", ManufacturerId = manufacturers["Creative"].Id, Channels = "5.1", DigitalAudioBits = 24, SnrDb = 116, SampleRateKhz = 192, Interface = "PCIe", Price = 1099m },
            new SoundCard { Name = "Sound Blaster Audigy FX", ManufacturerId = manufacturers["Creative"].Id, Channels = "5.1", DigitalAudioBits = 24, SnrDb = 106, SampleRateKhz = 192, Interface = "PCIe", Price = 549m }
        });

        AddIfEmpty(context, context.UpsSystems, new[]
        {
            new Ups { Name = "Back-UPS 700VA", ManufacturerId = manufacturers["APC"].Id, CapacityVa = 700, CapacityWatts = 390, Price = 1299m },
            new Ups { Name = "UPS 1000VA", ManufacturerId = manufacturers["CyberPower"].Id, CapacityVa = 1000, CapacityWatts = 600, Price = 1899m }
        });

        AddIfEmpty(context, context.OperatingSystems, new[]
        {
            new OperatingSystem { Name = "Windows 11 Home", ManufacturerId = manufacturers["Microsoft"].Id, Architecture = "64-bit", MaxMemoryGB = 128, Price = 1499m },
            new OperatingSystem { Name = "Windows 11 Pro", ManufacturerId = manufacturers["Microsoft"].Id, Architecture = "64-bit", MaxMemoryGB = 2000, Price = 2499m }
        });

        AddIfEmpty(context, context.CaseAccessories, new[]
        {
            new CaseAccessory { Name = "Vertical GPU Mount", ManufacturerId = manufacturers["Thermaltake"].Id, Type = "Mount", FormFactor = "PCIe", Price = 599m },
            new CaseAccessory { Name = "HDD Tray Kit", ManufacturerId = manufacturers["Fractal Design"].Id, Type = "Drive tray", FormFactor = "3.5", Price = 199m }
        });
    }

    private static void SeedLookups(DataContext context)
    {
        var manufacturerNames = new[]
        {
            "Intel", "AMD", "NVIDIA", "Corsair", "ASUS", "MSI", "Gigabyte", "Kingston",
            "Seagate", "Western Digital", "Samsung", "Logitech", "SteelSeries", "NZXT",
            "be quiet!", "AOC", "Razer", "Creative", "EVGA", "Thermaltake", "Fractal Design",
            "Philips", "Dell", "HP", "Lenovo", "Arctic", "APC", "CyberPower", "Microsoft"
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
}
