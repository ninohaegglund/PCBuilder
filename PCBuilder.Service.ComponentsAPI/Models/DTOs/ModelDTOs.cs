namespace PCBuilder.Service.ComponentsAPI.Models.DTOs
{
    public class CaseAccessoryDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public string? FormFactor { get; set; }
        public decimal? Price { get; set; }
    }

    public class CaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;

        public string? Type { get; set; }
        public int? IncludedPowerSupplyWatts { get; set; }
        public int? MaxGpuLengthMm { get; set; }
        public int? MaxCpuCoolerHeightMm { get; set; }
        public int? MaxRadiatorSizeMm { get; set; }
        public string? SidePanel { get; set; }
        public decimal? ExternalVolumeLiters { get; set; }
        public int? Internal35Bays { get; set; }
        public int? FanMountCount { get; set; }
        public decimal? Price { get; set; }
    }

    public class CaseFanDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;

        public int SizeMM { get; set; }
        public int? RpmMin { get; set; }
        public int? RpmMax { get; set; }
        public decimal? AirflowMin { get; set; }
        public decimal? AirflowMax { get; set; }
        public decimal? NoiseLevelMin { get; set; }
        public decimal? NoiseLevelMax { get; set; }
        public bool Pwm { get; set; }
        public decimal? Price { get; set; }
    }

    public class CPUCoolerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;

        public bool IsAio { get; set; }
        public int? RadiatorSize { get; set; }
        public int? MaxTdpWatts { get; set; }
        public int? HeightMm { get; set; }
        public int? RpmMin { get; set; }
        public int? RpmMax { get; set; }
        public decimal? NoiseLevelMin { get; set; }
        public decimal? NoiseLevelMax { get; set; }
        public decimal? Price { get; set; }
    }

    public class CPUDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;

        public int? CoreCount { get; set; }
        public decimal? CoreClock { get; set; }
        public decimal? BoostClock { get; set; }
        public string? Microarchitecture { get; set; }
        public int? Tdp { get; set; }
        public string? IntegratedGraphics { get; set; }
        public decimal? Price { get; set; }
    }

    public class ExternalStorageDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public string? Interface { get; set; }
        public long CapacityGB { get; set; }
        public decimal? PricePerGB { get; set; }
        public decimal? Price { get; set; }
    }

    public class FanControllerDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int? Channels { get; set; }
        public int? ChannelWattage { get; set; }
        public bool Pwm { get; set; }
        public string? FormFactor { get; set; }
        public decimal? Price { get; set; }
    }

    public class GPUDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;

        public int? Tdp { get; set; }
        public string? Chipset { get; set; }
        public int? MemoryGB { get; set; }
        public int? CoreClock { get; set; }
        public int? BoostClock { get; set; }
        public int? LengthMM { get; set; }
        public decimal? Price { get; set; }
    }

    public class HeadphonesDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public int? FrequencyMinHz { get; set; }
        public int? FrequencyMaxKhz { get; set; }
        public bool Microphone { get; set; }
        public bool Wireless { get; set; }
        public string? EnclosureType { get; set; }
        public decimal? Price { get; set; }
    }

    public class InternalStorageDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public long CapacityGB { get; set; }
        public string Type { get; set; } = null!;
        public string? FormFactor { get; set; }
        public string? Interface { get; set; }
        public int? CacheMB { get; set; }
        public decimal? Price { get; set; }
        public decimal? PricePerGB { get; set; }
    }

    public class KeyboardDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Style { get; set; }
        public string? Switches { get; set; }
        public string? Backlit { get; set; }
        public bool Tenkeyless { get; set; }
        public string? Connection { get; set; }
        public decimal? Price { get; set; }
    }

    public class MonitorDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public decimal ScreenSizeInches { get; set; }
        public int ResolutionWidth { get; set; }
        public int ResolutionHeight { get; set; }
        public int RefreshRateHz { get; set; }
        public decimal? ResponseTimeMs { get; set; }
        public string? PanelType { get; set; }
        public string? AspectRatio { get; set; }
    }

    public class MotherboardDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;

        public string Socket { get; set; } = null!;
        public string? FormFactor { get; set; }
        public int? MaxMemoryGB { get; set; }
        public int? MemorySlots { get; set; }
        public bool? HasWiFi { get; set; }
        public decimal? Price { get; set; }
    }

    public class MouseDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? TrackingMethod { get; set; }
        public string? Connection { get; set; }
        public int? MaxDpi { get; set; }
        public string? HandOrientation { get; set; }
        public decimal? Price { get; set; }
    }

    public class PSUDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;

        public string? Type { get; set; }
        public string? EfficiencyRating { get; set; }
        public int Wattage { get; set; }
        public string? Modular { get; set; }
        public decimal? Price { get; set; }
    }

    public class OperatingSystemDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Architecture { get; set; }
        public int? MaxMemoryGB { get; set; }
        public decimal? Price { get; set; }
    }

    public class RAMDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public int? CapacityPerModuleGB { get; set; }

        public int TotalCapacityGB { get; set; }
        public int ModulesCount { get; set; }
        public int SpeedMTs { get; set; }
        public int? CasLatency { get; set; }
        public decimal? Price { get; set; }
    }

    public class SoundCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;

        public decimal? Price { get; set; }
        public string? Channels { get; set; }
        public int? DigitalAudioBits { get; set; }
        public int? SnrDb { get; set; }
        public int? SampleRateKhz { get; set; }
        public string? Chipset { get; set; }
        public string? Interface { get; set; }
    }

    public class SpeakersDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Configuration { get; set; }
        public decimal? Wattage { get; set; }
        public int? FrequencyMinHz { get; set; }
        public int? FrequencyMaxKhz { get; set; }
        public decimal? Price { get; set; }
    }

    public class UpsDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int? CapacityWatts { get; set; }
        public int? CapacityVa { get; set; }
        public decimal? Price { get; set; }
    }

    public class WebcamDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Resolutions { get; set; }
        public string? Connection { get; set; }
        public string? FocusType { get; set; }
        public string? SupportedOs { get; set; }
        public int? FovDegrees { get; set; }
        public decimal? Price { get; set; }
    }
}