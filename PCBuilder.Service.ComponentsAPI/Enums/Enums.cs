namespace PCBuilder.Services.ComponentsAPI.Models.Components;

// CPU-sockets
public enum CPUSocket
{
    LGA1151,
    LGA1200,
    LGA1700,
    AM4,
    AM5,
    TRX40
}

// Typ av CPU-kylare
public enum CoolingType
{
    Air,
    Liquid
}

// RAM-typer
public enum RAMType
{
    DDR3,
    DDR4,
    DDR5
}

// GPU-gränssnitt
public enum GPUInterface
{
    PCIe3,
    PCIe4,
    PCIe5
}

// Storage interface
public enum StorageInterface
{
    SATA,
    NVMe
}

// Form factor för SSD
public enum SSDFormFactor
{
    M2_2280,
    M2_2260,
    M2_2242,
    _2_5Inch 
}

// Chassi storlek
public enum CaseFormFactor
{
    MiniITX,
    MicroATX,
    ATX,
    EATX
}

// Keyboard switch-typ
public enum SwitchType
{
    Linear,
    Tactile,
    Clicky
}

// Monitor resolution
public enum MonitorResolution
{
    R1080p,
    R1440p,
    R2160p 
}
