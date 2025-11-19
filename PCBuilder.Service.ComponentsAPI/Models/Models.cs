

namespace PCBuilder.Service.ComponentsAPI.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Cpu> Cpus { get; set; } = new List<Cpu>();
        public ICollection<VideoCard> VideoCards { get; set; } = new List<VideoCard>();
        public ICollection<Motherboard> Motherboards { get; set; } = new List<Motherboard>();
        public ICollection<MemoryKit> MemoryKits { get; set; } = new List<MemoryKit>();
        public ICollection<Case> Cases { get; set; } = new List<Case>();
        public ICollection<PowerSupply> PowerSupplies { get; set; } = new List<PowerSupply>();
        public ICollection<CpuCooler> CpuCoolers { get; set; } = new List<CpuCooler>();
        public ICollection<CaseFan> CaseFans { get; set; } = new List<CaseFan>();
        public ICollection<FanController> FanControllers { get; set; } = new List<FanController>();
        public ICollection<Monitor> Monitors { get; set; } = new List<Monitor>();
        public ICollection<Mouse> Mice { get; set; } = new List<Mouse>();
        public ICollection<Keyboard> Keyboards { get; set; } = new List<Keyboard>();
        public ICollection<Headphones> Headphones { get; set; } = new List<Headphones>();
        public ICollection<Speakers> Speakers { get; set; } = new List<Speakers>();
        public ICollection<Webcam> Webcams { get; set; } = new List<Webcam>();
    }

    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<VideoCard> VideoCards { get; set; } = new List<VideoCard>();
        public ICollection<MemoryKit> MemoryKits { get; set; } = new List<MemoryKit>();
        public ICollection<Motherboard> Motherboards { get; set; } = new List<Motherboard>();
        public ICollection<Case> Cases { get; set; } = new List<Case>();
        public ICollection<PowerSupply> PowerSupplies { get; set; } = new List<PowerSupply>();
        public ICollection<CpuCooler> CpuCoolers { get; set; } = new List<CpuCooler>();
        public ICollection<CaseFan> CaseFans { get; set; } = new List<CaseFan>();
        public ICollection<FanController> FanControllers { get; set; } = new List<FanController>();
        public ICollection<ExternalHardDrive> ExternalHardDrives { get; set; } = new List<ExternalHardDrive>();
        public ICollection<Headphones> Headphones { get; set; } = new List<Headphones>();
        public ICollection<Speakers> Speakers { get; set; } = new List<Speakers>();
        public ICollection<Mouse> Mice { get; set; } = new List<Mouse>();
        public ICollection<Keyboard> Keyboards { get; set; } = new List<Keyboard>();
    }

    public class FormFactor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class Cpu
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        public int? CoreCount { get; set; }
        public decimal? CoreClock { get; set; }    
        public decimal? BoostClock { get; set; }     
        public string? Microarchitecture { get; set; }
        public int? Tdp { get; set; }                 
        public string? IntegratedGraphics { get; set; }  
        public decimal? Price { get; set; }
    }

    public class VideoCard
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        public string? Chipset { get; set; }          
        public int? MemoryGB { get; set; }
        public int? CoreClock { get; set; }       
        public int? BoostClock { get; set; }         
        public int? LengthMM { get; set; }
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
        public decimal? Price { get; set; }
    }

    public class MemoryKit
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TotalCapacityGB { get; set; }
        public int ModulesCount { get; }
        public int CapacityPerModuleGB => TotalCapacityGB / ModulesCount;
        public int SpeedMTs { get; set; }            
        public int? CasLatency { get; set; }
        public decimal? FirstWordLatency { get; set; }
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
        public decimal? Price { get; set; }
        public decimal? PricePerGB => TotalCapacityGB > 0 ? Price / TotalCapacityGB : null;
    }

    public class Motherboard
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        public string Socket { get; set; } = null!;    
        public int? FormFactorId { get; set; }
        public FormFactor? FormFactor { get; set; }
        public int? MaxMemoryGB { get; set; }
        public int? MemorySlots { get; set; }
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
        public bool? HasWiFi { get; set; }
        public decimal? Price { get; set; }
    }

    public class Case
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Type { get; set; }                
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
        public int? IncludedPowerSupplyWatts { get; set; } 
        public string? SidePanel { get; set; }    
        public decimal? ExternalVolumeLiters { get; set; }
        public int? Internal35Bays { get; set; }
        public decimal? Price { get; set; }
    }

    public class PowerSupply
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Type { get; set; }      
        public string? EfficiencyRating { get; set; }  
        public int Wattage { get; set; }
        public string? Modular { get; set; }        
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
        public decimal? Price { get; set; }
    }

    public class CpuCooler
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsAio { get; set; } = false;       
        public int? RadiatorSize { get; set; }        
        public int? RpmMin { get; set; }
        public int? RpmMax { get; set; }
        public decimal? NoiseLevelMin { get; set; }
        public decimal? NoiseLevelMax { get; set; }
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
        public decimal? Price { get; set; }
    }

    public class CaseFan
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SizeMM { get; set; }              
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
        public int? RpmMin { get; set; }
        public int? RpmMax { get; set; }
        public decimal? AirflowMin { get; set; }
        public decimal? AirflowMax { get; set; }
        public decimal? NoiseLevelMin { get; set; }
        public decimal? NoiseLevelMax { get; set; }
        public bool Pwm { get; set; }
        public decimal? Price { get; set; }
    }

    public class InternalHardDrive
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public long CapacityGB { get; set; }
        public string Type { get; set; } = null!;      
        public string? FormFactor { get; set; }        
        public string? Interface { get; set; } 
        public int? CacheMB { get; set; }
        public decimal? Price { get; set; }
        public decimal? PricePerGB => CapacityGB > 0 ? Price / CapacityGB : null;
    }

    public class CaseAccessory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? Type { get; set; }                
        public string? FormFactor { get; set; }     
    }

    public class FanController
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public int? Channels { get; set; }
        public int? ChannelWattage { get; set; }
        public bool Pwm { get; set; }
        public string? FormFactor { get; set; } 
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
    }

    public class OperatingSystem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? Architecture { get; set; }   
        public int? MaxMemoryGB { get; set; }
    }

    public class SoundCard
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? Channels { get; set; }            
        public int? DigitalAudioBits { get; set; }
        public int? SnrDb { get; set; }
        public int? SampleRateKhz { get; set; }
        public string? Chipset { get; set; }
        public string? Interface { get; set; }      
    }


    public class Speakers
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? Configuration { get; set; }
        public decimal? Wattage { get; set; }
        public int? FrequencyMinHz { get; set; }
        public int? FrequencyMaxKhz { get; set; }
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
    }

    public class Webcam
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? Resolutions { get; set; }     
        public string? Connection { get; set; }
        public string? FocusType { get; set; }          
        public string? SupportedOs { get; set; }          
        public int? FovDegrees { get; set; }
    }

    public class ExternalHardDrive
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? Type { get; set; }               
        public string? Interface { get; set; }
        public long CapacityGB { get; set; }
        public decimal? PricePerGB { get; set; }
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
    }

    public class Ups
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public int? CapacityWatts { get; set; }
        public int? CapacityVa { get; set; }
    }

    public class Headphones
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? Type { get; set; }           
        public int? FrequencyMinHz { get; set; }
        public int? FrequencyMaxKhz { get; set; }
        public bool Microphone { get; set; }
        public bool Wireless { get; set; }
        public string? EnclosureType { get; set; }       
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
    }

    public class Monitor
    {
        public int Id { get; set; }
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

    public class Mouse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? TrackingMethod { get; set; }       
        public string? Connection { get; set; }      
        public int? MaxDpi { get; set; }
        public string? HandOrientation { get; set; }    
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
    }

    public class Keyboard
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? Style { get; set; }              
        public string? Switches { get; set; }
        public string? Backlit { get; set; }  
        
        public bool Tenkeyless { get; set; }
        public string? Connection { get; set; }
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
    }
}