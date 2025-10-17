using PCBuilder.Service.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models.Components;
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
                    IntegratedGraphics = "Intel UHD Graphics 770",
                    Description = "Flaggskeppsprocessor från Intel med 24 kärnor och 32 trådar, optimal för gaming och tunga arbetsuppgifter."
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
                    IntegratedGraphics = "Intel UHD Graphics 770",
                    Description = "Kraftfull i7-processor för både gaming och produktivitet, med stöd för HyperThreading och integrerad grafik."
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
                    HasIntegratedGraphics = true,
                    Description = "AMD:s toppmodell för entusiaster, med Zen 4-arkitektur och 16 kärnor. Perfekt för tunga beräkningar."
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
                    HasIntegratedGraphics = false,
                    Description = "Ryzen 7-processor med 3D V-Cache för maximal spelprestanda, 8 kärnor och låg TDP."
                }
            );
        }

        // Chassi Cooling
        if (!context.ChassiCooling.Any())
        {
            context.ChassiCooling.AddRange(
                new ChassiCooling { ModelName = "Noctua NF-A12x25 PWM", Manufacturer = "Noctua", FanSizeMm = 120, Rpm = 2000, CoolingCapacityW = 40, Description = "Premium 120mm chassifläkt från Noctua med låg ljudnivå och hög kylkapacitet." },
                new ChassiCooling { ModelName = "be quiet! Silent Wings 3", Manufacturer = "be quiet!", FanSizeMm = 140, Rpm = 1450, CoolingCapacityW = 35, Description = "Tystgående 140mm fläkt för optimal kylning och minimalt ljud." },
                new ChassiCooling { ModelName = "Corsair ML120 Pro", Manufacturer = "Corsair", FanSizeMm = 120, Rpm = 2400, CoolingCapacityW = 45, Description = "Högpresterande 120mm fläkt med magnetisk levitation för maximal luftflöde." },
                new ChassiCooling { ModelName = "ARCTIC F12", Manufacturer = "ARCTIC", FanSizeMm = 120, Rpm = 1350, CoolingCapacityW = 30, Description = "Prisvärd och effektiv 120mm fläkt för allroundbruk." }
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
                    },
                    Description = "Prisbelönt luftkylare med dubbla torn och tystgående 140mm-fläktar. Passar både Intel och AMD."
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
                    },
                    Description = "Tyst och effektiv luftkylare, perfekt för överklockning och tysta byggen."
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
                    },
                    Description = "Kraftfull 360mm AIO-vattenkylare med RGB och låg ljudnivå."
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
                    },
                    Description = "Exklusiv vattenkylare med LCD-display och hög kylkapacitet för krävande system."
                }
            );
        }

        // GPU
        if (!context.GPUs.Any())
        {
            context.GPUs.AddRange(
                new NvidiaGpu { ModelName = "NVIDIA GeForce RTX 4090", Manufacturer = "NVIDIA", VramGb = 24, VramType = VRAMType.GDDR6X, LengthMm = 304, PowerConsumptionW = 450, TDP = 450, Interface = GPUInterface.PCIe4, CudaCores = 16384, TensorCores = 512, Description = "Marknadens snabbaste grafikkort för gaming och kreativa applikationer." },
                new NvidiaGpu { ModelName = "NVIDIA GeForce RTX 4080", Manufacturer = "NVIDIA", VramGb = 16, VramType = VRAMType.GDDR6X, LengthMm = 304, PowerConsumptionW = 320, TDP = 320, Interface = GPUInterface.PCIe4, CudaCores = 9728, TensorCores = 304, Description = "Högpresterande grafikkort för 4K gaming och rendering." },
                new AmdGpu { ModelName = "AMD Radeon RX 7900 XTX", Manufacturer = "AMD", VramGb = 24, VramType = VRAMType.GDDR6, LengthMm = 336, PowerConsumptionW = 355, TDP = 355, Interface = GPUInterface.PCIe4, StreamProcessors = 6144, InfinityCache = true, Description = "AMD:s toppmodell med Infinity Cache och 24GB VRAM för extrem prestanda." },
                new AmdGpu { ModelName = "AMD Radeon RX 7900 XT", Manufacturer = "AMD", VramGb = 20, VramType = VRAMType.GDDR6, LengthMm = 330, PowerConsumptionW = 300, TDP = 300, Interface = GPUInterface.PCIe4, StreamProcessors = 5376, InfinityCache = true, Description = "Högpresterande grafikkort för gaming i höga upplösningar." }
            );
        }

        // RAM
        if (!context.RAMModules.Any())
        {
            context.RAMModules.AddRange(
                new RAM { ModelName = "Corsair Vengeance DDR5", Manufacturer = "Corsair", CapacityGb = 32, SpeedMHz = 6000, Type = RAMType.DDR5, Description = "Snabb DDR5 RAM-modul på 32GB för moderna system." },
                new RAM { ModelName = "G.Skill Trident Z5 RGB", Manufacturer = "G.Skill", CapacityGb = 32, SpeedMHz = 6400, Type = RAMType.DDR5, Description = "Stilren DDR5 RAM med RGB och hög hastighet." },
                new RAM { ModelName = "Kingston Fury Beast DDR5", Manufacturer = "Kingston", CapacityGb = 16, SpeedMHz = 5200, Type = RAMType.DDR5, Description = "Prisvärd och snabb 16GB DDR5 RAM-modul." }
            );
        }

        // PSU
        if (!context.PSUs.Any())
        {
            context.PSUs.AddRange(
                new ModularPSU { ModelName = "Corsair RM850x", Manufacturer = "Corsair", Wattage = 850, EfficiencyRating = EfficiencyRating.Gold, PowerConsumptionW = 10, FullyModular = true, NumberOfCables = 12, Description = "Modulärt nätaggregat på 850W med hög verkningsgrad och tyst gång." },
                new ModularPSU { ModelName = "Seasonic Prime TX-1000", Manufacturer = "Seasonic", Wattage = 1000, EfficiencyRating = EfficiencyRating.Titanium, PowerConsumptionW = 12, FullyModular = true, NumberOfCables = 14, Description = "Kraftfullt och tyst modulärt nätaggregat på 1000W, Titanium-certifierat." },
                new NonModularPSU { ModelName = "EVGA 600 W1", Manufacturer = "EVGA", Wattage = 600, EfficiencyRating = EfficiencyRating.Bronze, PowerConsumptionW = 8, FixedCables = 5, Description = "Prisvärt 600W nätaggregat med fasta kablar och stabil prestanda." }
            );
        }

        // Storage
        if (!context.Storages.Any())
        {
            context.Storages.AddRange(
                new SSD { Manufacturer = "Samsung", ModelName = "980 Pro", CapacityGb = 1000, Interface = StorageInterface.NVMe, PowerConsumptionW = 8, ReadSpeedMb = 7000, WriteSpeedMb = 5000, FormFactor = SSDFormFactor.M2_2280, NandType = "3D TLC", Description = "Supersnabb NVMe SSD med 1TB lagring och hög tillförlitlighet." },
                new SSD { Manufacturer = "WD", ModelName = "Black SN850", CapacityGb = 2000, Interface = StorageInterface.NVMe, PowerConsumptionW = 10, ReadSpeedMb = 7000, WriteSpeedMb = 5300, FormFactor = SSDFormFactor.M2_2280, NandType = "3D TLC", Description = "2TB NVMe SSD med hög prestanda för gaming och produktivitet." },
                new HDD { Manufacturer = "Seagate", ModelName = "Barracuda", CapacityGb = 2000, Interface = StorageInterface.SATA, PowerConsumptionW = 6, ReadSpeedMb = 220, WriteSpeedMb = 220, Rpm = 7200, CacheMb = 256, Description = "2TB mekanisk hårddisk med 7200rpm för lagring av stora filer." }
            );
        }

        // Chassi
        if (!context.Cases.Any())
        {
            context.Cases.AddRange(
                new Chassi { Manufacturer = "NZXT", ModelName = "H710", ChassiMaterial = ChassiMaterial.Steel, MaxGpuLengthMm = 413, FormFactor = CaseFormFactor.ATX, Description = "Stilrent ATX-chassi med gott om utrymme och bra kabeldragning." },
                new Chassi { Manufacturer = "Fractal Design", ModelName = "Meshify C", ChassiMaterial = ChassiMaterial.Aluminum, MaxGpuLengthMm = 315, FormFactor = CaseFormFactor.ATX, Description = "Luftigt chassi med meshfront för maximalt luftflöde." },
                new Chassi { Manufacturer = "Corsair", ModelName = "4000D Airflow", ChassiMaterial = ChassiMaterial.Steel, MaxGpuLengthMm = 360, FormFactor = CaseFormFactor.ATX, Description = "Prisvärt ATX-chassi med fokus på luftflöde och enkel installation." },
                new Chassi { Manufacturer = "Cooler Master", ModelName = "MasterBox NR600", ChassiMaterial = ChassiMaterial.TemperedGlass, MaxGpuLengthMm = 410, FormFactor = CaseFormFactor.ATX, Description = "Elegant chassi med härdat glas och modern design." }
            );
        }

        // Monitors
        if (!context.Monitors.Any())
        {
            context.Monitors.AddRange(
                new DisplayMonitor { Manufacturer = "Dell", ModelName = "U2723QE", SizeInches = 27, Hz = RefreshRate.R144Hz, Resolution = MonitorResolution.R1440p, Description = "27-tums QHD-skärm med 144Hz uppdateringsfrekvens och hög färgåtergivning." },
                new DisplayMonitor { Manufacturer = "ASUS", ModelName = "ROG Swift PG32UQX", SizeInches = 32, Hz = RefreshRate.R144Hz, Resolution = MonitorResolution.R2160p, Description = "32-tums 4K-skärm med hög uppdateringsfrekvens för gaming." },
                new DisplayMonitor { Manufacturer = "LG", ModelName = "27GN950", SizeInches = 27, Hz = RefreshRate.R144Hz, Resolution = MonitorResolution.R2160p, Description = "UHD 27-tums gaming-skärm med snabb respons och hög upplösning." },
                new DisplayMonitor { Manufacturer = "Acer", ModelName = "Predator XB273K", SizeInches = 27, Hz = RefreshRate.R144Hz, Resolution = MonitorResolution.R2160p, Description = "4K-gamingskärm på 27 tum med 144Hz och G-Sync-stöd." }
            );
        }

        // Keyboards
        if (!context.Keyboards.Any())
        {
            context.Keyboards.AddRange(
                new Keyboard { Manufacturer = "Corsair", ModelName = "K100 RGB", IsMechanical = true, SwitchType = SwitchType.Linear, IsWireless = false, HasBacklight = true, Layout = "US", SizePercent = 100, Description = "Mekaniskt RGB-tangentbord med linjära switchar och fullstor layout." },
                new Keyboard { Manufacturer = "Razer", ModelName = "Huntsman V2", IsMechanical = true, SwitchType = SwitchType.Clicky, IsWireless = false, HasBacklight = true, Layout = "US", SizePercent = 100, Description = "Gamingtangentbord med klickiga switchar och snabb respons." },
                new Keyboard { Manufacturer = "SteelSeries", ModelName = "Apex Pro", IsMechanical = true, SwitchType = SwitchType.Tactile, IsWireless = false, HasBacklight = true, Layout = "US", SizePercent = 100, Description = "Tangentbord med justerbar aktiveringspunkt och RGB-belysning." },
                new Keyboard { Manufacturer = "Logitech", ModelName = "G915 TKL", IsMechanical = true, SwitchType = SwitchType.Tactile, IsWireless = true, HasBacklight = true, Layout = "US", SizePercent = 87, Description = "Trådlöst TKL-tangentbord med låg profil och lång batteritid." }
            );
        }

        // Mice
        if (!context.Mice.Any())
        {
            context.Mice.AddRange(
                new Mouse { Manufacturer = "Logitech", ModelName = "G502 Hero", Dpi = 16000, IsWireless = false, NumberOfButtons = 11, Description = "Prisbelönt gamingmus med hög precision och många programmerbara knappar." },
                new Mouse { Manufacturer = "Razer", ModelName = "DeathAdder V3", Dpi = 20000, IsWireless = false, NumberOfButtons = 8, Description = "Klassisk gamingmus med hög DPI och ergonomisk design." },
                new Mouse { Manufacturer = "SteelSeries", ModelName = "Rival 3", Dpi = 12000, IsWireless = false, NumberOfButtons = 6, Description = "Lätt och snabb mus för e-sport och snabba rörelser." },
                new Mouse { Manufacturer = "Corsair", ModelName = "Dark Core RGB", Dpi = 18000, IsWireless = true, NumberOfButtons = 9, Description = "Trådlös mus med RGB och anpassningsbara sidogrepp." }
            );
        }

        // Headsets
        if (!context.Headsets.Any())
        {
            context.Headsets.AddRange(
                new Headset { Manufacturer = "SteelSeries", ModelName = "Arctis 7", IsWireless = true, HasMicrophone = true, Description = "Trådlöst headset med lång batteritid och klart ljud, perfekt för gaming." },
                new Headset { Manufacturer = "HyperX", ModelName = "Cloud II", IsWireless = false, HasMicrophone = true, Description = "Klassiskt trådbundet headset med bekväm passform och bra mikrofon." },
                new Headset { Manufacturer = "Logitech", ModelName = "G Pro X", IsWireless = false, HasMicrophone = true, Description = "Headset för proffs med utbytbara öronkuddar och mikrofon med Blue VO!CE." },
                new Headset { Manufacturer = "Corsair", ModelName = "Virtuoso RGB", IsWireless = true, HasMicrophone = true, Description = "Premium trådlöst headset med RGB och kristallklart ljud." }
            );
        }

        // Speakers
        if (!context.Speakers.Any())
        {
            context.Speakers.AddRange(
                new Speaker { Manufacturer = "Bose", ModelName = "Companion 5", Watt = 60, IsWireless = false, Description = "Kompakta högtalare med fylligt ljud och klassisk Bose-kvalitet." },
                new Speaker { Manufacturer = "Logitech", ModelName = "Z625", Watt = 200, IsWireless = false, Description = "Kraftfullt 2.1-högtalarsystem med djup bas och flera ingångar." },
                new Speaker { Manufacturer = "Creative", ModelName = "Pebble Plus", Watt = 20, IsWireless = false, Description = "Snygga och prisvärda högtalare för skrivbordet med extra basmodul." },
                new Speaker { Manufacturer = "Edifier", ModelName = "R1280DB", Watt = 42, IsWireless = true, Description = "Bluetooth-högtalare med klassisk design och tydligt ljud." }
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
                    MaxPcieLengthMm = 350,
                    Description = "ATX-moderkort med B550-chipset, stöd för flera grafikkort och hög RAM-kapacitet."
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
                    MaxPcieLengthMm = 300,
                    Description = "Micro-ATX-moderkort för Intel LGA1200, kompakt och prisvärt."
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
                    MaxPcieLengthMm = 270,
                    Description = "Kompakt Mini-ITX-moderkort med hög prestanda för små byggen."
                }
            );
        }

        context.SaveChanges();
    }
}