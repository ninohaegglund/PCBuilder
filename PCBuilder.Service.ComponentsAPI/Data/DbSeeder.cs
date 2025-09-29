using PCBuilder.Service.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models;
using PCBuilder.Services.ComponentsAPI.Models.Components;
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

public static class DbSeeder
{
    public static void Seed(DataContext context)
    {
        // CPU
        if (!context.CPUs.Any())
        {
            context.CPUs.AddRange(
                new IntelCpu
                {
                    ModelName = "Intel Core i9-13900K",
                    Manufacturer = "Intel",
                    Cores = 24,
                    Threads = 32,
                    BaseClockGhz = 3.0,
                    BoostClockGhz = 5.8,
                    TDP = 125,
                    PowerConsumptionW = 125,
                    Socket = CPUSocket.LGA1700,
                    HyperThreading = true,
                    Generation = "13th Gen",
                    IntegratedGraphics = "Intel UHD Graphics 770"
                },
                new IntelCpu
                {
                    ModelName = "Intel Core i7-13700K",
                    Manufacturer = "Intel",
                    Cores = 16,
                    Threads = 24,
                    BaseClockGhz = 3.4,
                    BoostClockGhz = 5.4,
                    TDP = 125,
                    PowerConsumptionW = 125,
                    Socket = CPUSocket.LGA1700,
                    HyperThreading = true,
                    Generation = "13th Gen",
                    IntegratedGraphics = "Intel UHD Graphics 770"
                },
                new AmdCpu
                {
                    ModelName = "AMD Ryzen 9 7950X",
                    Manufacturer = "AMD",
                    Cores = 16,
                    Threads = 32,
                    BaseClockGhz = 4.5,
                    BoostClockGhz = 5.7,
                    TDP = 170,
                    PowerConsumptionW = 170,
                    Socket = CPUSocket.AM5,
                    Architecture = "Zen 4",
                    SimultaneousMultithreading = true,
                    HasIntegratedGraphics = true
                },
                new AmdCpu
                {
                    ModelName = "AMD Ryzen 7 7800X3D",
                    Manufacturer = "AMD",
                    Cores = 8,
                    Threads = 16,
                    BaseClockGhz = 4.2,
                    BoostClockGhz = 5.0,
                    TDP = 120,
                    PowerConsumptionW = 120,
                    Socket = CPUSocket.AM5,
                    Architecture = "Zen 4",
                    SimultaneousMultithreading = true,
                    HasIntegratedGraphics = false
                }
            );
        }

        // Chassi Cooling
        if (!context.ChassiCooling.Any())
        {
            context.ChassiCooling.AddRange(
                new ChassiCooling { ModelName = "Noctua NF-A12x25 PWM", Manufacturer = "Noctua", FanSizeMm = 120, Rpm = 2000, CoolingCapacityW = 40 },
                new ChassiCooling { ModelName = "be quiet! Silent Wings 3", Manufacturer = "be quiet!", FanSizeMm = 140, Rpm = 1450, CoolingCapacityW = 35 },
                new ChassiCooling { ModelName = "Corsair ML120 Pro", Manufacturer = "Corsair", FanSizeMm = 120, Rpm = 2400, CoolingCapacityW = 45 },
                new ChassiCooling { ModelName = "ARCTIC F12", Manufacturer = "ARCTIC", FanSizeMm = 120, Rpm = 1350, CoolingCapacityW = 30 }
            );
        }

        // CPU Cooling
        if (!context.CPUCoolers.Any())
        {
            context.CPUCoolers.AddRange(
                new AirCooler
                {
                    ModelName = "Noctua NH-D15",
                    Manufacturer = "Noctua",
                    CoolingCapacityW = 250,
                    NoiseLevelDb = 24,
                    Type = CoolingType.Air,
                    FanSizeMm = 140,
                    Rpm = 1500,
                    CompatibleSockets = new List<CoolerSocketCompatibility>
                    {
                new CoolerSocketCompatibility { Socket = CPUSocket.LGA1700 },
                new CoolerSocketCompatibility { Socket = CPUSocket.AM5 }
                    }
                },
                new AirCooler
                {
                    ModelName = "be quiet! Dark Rock Pro 4",
                    Manufacturer = "be quiet!",
                    CoolingCapacityW = 250,
                    NoiseLevelDb = 24,
                    Type = CoolingType.Air,
                    FanSizeMm = 135,
                    Rpm = 1500,
                    CompatibleSockets = new List<CoolerSocketCompatibility>
                    {
                new CoolerSocketCompatibility { Socket = CPUSocket.LGA1700 },
                new CoolerSocketCompatibility { Socket = CPUSocket.AM5 }
                    }
                },
                new WaterCooler
                {
                    ModelName = "Corsair H150i Elite",
                    Manufacturer = "Corsair",
                    CoolingCapacityW = 300,
                    NoiseLevelDb = 22,
                    Type = CoolingType.Liquid,
                    RadiatorSizeMm = 360,
                    CompatibleSockets = new List<CoolerSocketCompatibility>
                    {
                new CoolerSocketCompatibility { Socket = CPUSocket.LGA1700 },
                new CoolerSocketCompatibility { Socket = CPUSocket.AM5 }
                    }
                },
                new WaterCooler
                {
                    ModelName = "NZXT Kraken Z73",
                    Manufacturer = "NZXT",
                    CoolingCapacityW = 280,
                    NoiseLevelDb = 21,
                    Type = CoolingType.Liquid,
                    RadiatorSizeMm = 360,
                    CompatibleSockets = new List<CoolerSocketCompatibility>
                    {
                new CoolerSocketCompatibility { Socket = CPUSocket.LGA1700 },
                new CoolerSocketCompatibility { Socket = CPUSocket.AM5 }
                    }
                }
            );
        }
 

        // GPU
        if (!context.GPUs.Any())
        {
            context.GPUs.AddRange(
                new NvidiaGpu { ModelName = "NVIDIA GeForce RTX 4090", Manufacturer = "NVIDIA", VramGb = 24, VramType = VRAMType.GDDR6X, LengthMm = 304, PowerConsumptionW = 450, TDP = 450, Interface = GPUInterface.PCIe4, CudaCores = 16384, TensorCores = 512 },
                new NvidiaGpu { ModelName = "NVIDIA GeForce RTX 4080", Manufacturer = "NVIDIA", VramGb = 16, VramType = VRAMType.GDDR6X, LengthMm = 304, PowerConsumptionW = 320, TDP = 320, Interface = GPUInterface.PCIe4, CudaCores = 9728, TensorCores = 304 },
                new AmdGpu { ModelName = "AMD Radeon RX 7900 XTX", Manufacturer = "AMD", VramGb = 24, VramType = VRAMType.GDDR6, LengthMm = 336, PowerConsumptionW = 355, TDP = 355, Interface = GPUInterface.PCIe4, StreamProcessors = 6144, InfinityCache = true },
                new AmdGpu { ModelName = "AMD Radeon RX 7900 XT", Manufacturer = "AMD", VramGb = 20, VramType = VRAMType.GDDR6, LengthMm = 330, PowerConsumptionW = 300, TDP = 300, Interface = GPUInterface.PCIe4, StreamProcessors = 5376, InfinityCache = true }
            );
        }

        // RAM
        if (!context.RAMModules.Any())
        {
            context.RAMModules.AddRange(
                new RAM { ModelName = "Corsair Vengeance DDR5", Manufacturer = "Corsair", CapacityGb = 32, SpeedMHz = 6000, Type = RAMType.DDR5 },
                new RAM { ModelName = "G.Skill Trident Z5 RGB", Manufacturer = "G.Skill", CapacityGb = 32, SpeedMHz = 6400, Type = RAMType.DDR5 },
                new RAM { ModelName = "Kingston Fury Beast DDR5", Manufacturer = "Kingston", CapacityGb = 16, SpeedMHz = 5200, Type = RAMType.DDR5 }
            );
        }

        // PSU
        if (!context.PSUs.Any())
        {
            context.PSUs.AddRange(
                new ModularPSU { ModelName = "Corsair RM850x", Manufacturer = "Corsair", Wattage = 850, EfficiencyRating = EfficiencyRating.Gold, PowerConsumptionW = 10, FullyModular = true, NumberOfCables = 12 },
                new ModularPSU { ModelName = "Seasonic Prime TX-1000", Manufacturer = "Seasonic", Wattage = 1000, EfficiencyRating = EfficiencyRating.Titanium, PowerConsumptionW = 12, FullyModular = true, NumberOfCables = 14 },
                new NonModularPSU { ModelName = "EVGA 600 W1", Manufacturer = "EVGA", Wattage = 600, EfficiencyRating = EfficiencyRating.Bronze, PowerConsumptionW = 8, FixedCables = 5 }
            );
        }

        // Storage
        if (!context.Storages.Any())
        {
            context.Storages.AddRange(
                new SSD { Manufacturer = "Samsung", ModelName = "980 Pro", CapacityGb = 1000, Interface = StorageInterface.NVMe, PowerConsumptionW = 8, ReadSpeedMb = 7000, WriteSpeedMb = 5000, FormFactor = SSDFormFactor.M2_2280, NandType = "3D TLC" },
                new SSD { Manufacturer = "WD", ModelName = "Black SN850", CapacityGb = 2000, Interface = StorageInterface.NVMe, PowerConsumptionW = 10, ReadSpeedMb = 7000, WriteSpeedMb = 5300, FormFactor = SSDFormFactor.M2_2280, NandType = "3D TLC" },
                new HDD { Manufacturer = "Seagate", ModelName = "Barracuda", CapacityGb = 2000, Interface = StorageInterface.SATA, PowerConsumptionW = 6, ReadSpeedMb = 220, WriteSpeedMb = 220, Rpm = 7200, CacheMb = 256 }
            );
        }

        // Chassi
        if (!context.Cases.Any())
        {
            context.Cases.AddRange(
                new Chassi { Manufacturer = "NZXT", ModelName = "H710", ChassiMaterial = ChassiMaterial.Steel, MaxGpuLengthMm = 413, FormFactor = CaseFormFactor.ATX },
                new Chassi { Manufacturer = "Fractal Design", ModelName = "Meshify C", ChassiMaterial = ChassiMaterial.Aluminum, MaxGpuLengthMm = 315, FormFactor = CaseFormFactor.ATX },
                new Chassi { Manufacturer = "Corsair", ModelName = "4000D Airflow", ChassiMaterial = ChassiMaterial.Steel, MaxGpuLengthMm = 360, FormFactor = CaseFormFactor.ATX },
                new Chassi { Manufacturer = "Cooler Master", ModelName = "MasterBox NR600", ChassiMaterial = ChassiMaterial.TemperedGlass, MaxGpuLengthMm = 410, FormFactor = CaseFormFactor.ATX }
            );
        }

        // Monitors
        if (!context.Monitors.Any())
        {
            context.Monitors.AddRange(
                new DisplayMonitor { Manufacturer = "Dell", ModelName = "U2723QE", SizeInches = 27, Hz = RefreshRate.R144Hz, Resolution = MonitorResolution.R1440p },
                new DisplayMonitor { Manufacturer = "ASUS", ModelName = "ROG Swift PG32UQX", SizeInches = 32, Hz = RefreshRate.R144Hz, Resolution = MonitorResolution.R2160p },
                new DisplayMonitor { Manufacturer = "LG", ModelName = "27GN950", SizeInches = 27, Hz = RefreshRate.R144Hz, Resolution = MonitorResolution.R2160p },
                new DisplayMonitor { Manufacturer = "Acer", ModelName = "Predator XB273K", SizeInches = 27, Hz = RefreshRate.R144Hz, Resolution = MonitorResolution.R2160p }
            );
        }

        // Keyboards
        if (!context.Keyboards.Any())
        {
            context.Keyboards.AddRange(
                new Keyboard { Manufacturer = "Corsair", ModelName = "K100 RGB", IsMechanical = true, SwitchType = SwitchType.Linear, IsWireless = false, HasBacklight = true, Layout = "US", SizePercent = 100 },
                new Keyboard { Manufacturer = "Razer", ModelName = "Huntsman V2", IsMechanical = true, SwitchType = SwitchType.Clicky, IsWireless = false, HasBacklight = true, Layout = "US", SizePercent = 100 },
                new Keyboard { Manufacturer = "SteelSeries", ModelName = "Apex Pro", IsMechanical = true, SwitchType = SwitchType.Tactile, IsWireless = false, HasBacklight = true, Layout = "US", SizePercent = 100 },
                new Keyboard { Manufacturer = "Logitech", ModelName = "G915 TKL", IsMechanical = true, SwitchType = SwitchType.Tactile, IsWireless = true, HasBacklight = true, Layout = "US", SizePercent = 87 }
            );
        }

        // Mice
        if (!context.Mice.Any())
        {
            context.Mice.AddRange(
                new Mouse { Manufacturer = "Logitech", ModelName = "G502 Hero", Dpi = 16000, IsWireless = false, NumberOfButtons = 11 },
                new Mouse { Manufacturer = "Razer", ModelName = "DeathAdder V3", Dpi = 20000, IsWireless = false, NumberOfButtons = 8 },
                new Mouse { Manufacturer = "SteelSeries", ModelName = "Rival 3", Dpi = 12000, IsWireless = false, NumberOfButtons = 6 },
                new Mouse { Manufacturer = "Corsair", ModelName = "Dark Core RGB", Dpi = 18000, IsWireless = true, NumberOfButtons = 9 }
            );
        }

        // Headsets
        if (!context.Headsets.Any())
        {
            context.Headsets.AddRange(
                new Headset { Manufacturer = "SteelSeries", ModelName = "Arctis 7", IsWireless = true, HasMicrophone = true },
                new Headset { Manufacturer = "HyperX", ModelName = "Cloud II", IsWireless = false, HasMicrophone = true },
                new Headset { Manufacturer = "Logitech", ModelName = "G Pro X", IsWireless = false, HasMicrophone = true },
                new Headset { Manufacturer = "Corsair", ModelName = "Virtuoso RGB", IsWireless = true, HasMicrophone = true }
            );
        }

        // Speakers
        if (!context.Speakers.Any())
        {
            context.Speakers.AddRange(
                new Speaker { Manufacturer = "Bose", ModelName = "Companion 5", Watt = 60, IsWireless = false },
                new Speaker { Manufacturer = "Logitech", ModelName = "Z625", Watt = 200, IsWireless = false },
                new Speaker { Manufacturer = "Creative", ModelName = "Pebble Plus", Watt = 20, IsWireless = false },
                new Speaker { Manufacturer = "Edifier", ModelName = "R1280DB", Watt = 42, IsWireless = true }
            );
        }

        // Motherboards
        if (!context.Motherboards.Any())
        {
            context.Motherboards.AddRange(
                new AtxMotherboard
                {
                    ModelName = "MSI B550 Tomahawk",
                    Manufacturer = "MSI",
                    Socket = CPUSocket.AM4,
                    Chipset = "B550",
                    RamSlots = 4,
                    SupportedRamType = RAMType.DDR4,
                    MaxRamCapacityGb = 128,
                    PcieSlots = 2,
                    SupportsMultiGpu = true,
                    MaxPcieLengthMm = 350
                },
                new MicroAtxMotherboard
                {
                    ModelName = "ASRock B460M Steel Legend",
                    Manufacturer = "ASRock",
                    Socket = CPUSocket.LGA1200,
                    Chipset = "B460",
                    RamSlots = 2,
                    SupportedRamType = RAMType.DDR4,
                    MaxRamCapacityGb = 64,
                    PcieSlots = 1,
                    SupportsMultiGpu = false,
                    MaxPcieLengthMm = 300
                },
                new MiniItxMotherboard
                {
                    ModelName = "Gigabyte Z490I Aorus Ultra",
                    Manufacturer = "Gigabyte",
                    Socket = CPUSocket.LGA1200,
                    Chipset = "Z490",
                    RamSlots = 2,
                    SupportedRamType = RAMType.DDR4,
                    MaxRamCapacityGb = 64,
                    PcieSlots = 1,
                    SupportsMultiGpu = false,
                    MaxPcieLengthMm = 270
                }
            );
        }


        // PCIe Cables
        if (!context.PCIeCables.Any())
        {
            context.PCIeCables.AddRange(
                new PCIeCable { ConnectorType = "6+2 pin", LengthCm = 50 },
                new PCIeCable { ConnectorType = "8 pin", LengthCm = 60 },
                new PCIeCable { ConnectorType = "6 pin", LengthCm = 45 }
            );
        }

        // Power Cables
        if (!context.PowerCables.Any())
        {
            context.PowerCables.AddRange(
                new PowerCable { ConnectorType = "24 pin ATX", LengthCm = 50 },
                new PowerCable { ConnectorType = "8 pin EPS", LengthCm = 60 },
                new PowerCable { ConnectorType = "4+4 pin EPS", LengthCm = 55 }
            );
        }

        // SATA Cables
        if (!context.SataCables.Any())
        {
            context.SataCables.AddRange(
                new SataCable { LengthCm = 50, IsRightAngled = false },
                new SataCable { LengthCm = 30, IsRightAngled = true },
                new SataCable { LengthCm = 40, IsRightAngled = false }
            );
        }

        context.SaveChanges();
    }
}
