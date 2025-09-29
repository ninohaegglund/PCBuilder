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

public enum CoolingType
{
    Air,
    Liquid
}
public enum RAMType
{
    DDR3,
    DDR4,
    DDR5
}
public enum GPUInterface
{
    PCIe3,
    PCIe4,
    PCIe5
}
public enum StorageInterface
{
    SATA,
    NVMe
}
public enum SSDFormFactor
{
    M2_2280,
    M2_2260,
    M2_2242,
    _2_5Inch 
}
public enum CaseFormFactor
{
    MiniITX,
    MicroATX,
    ATX,
    EATX
}
public enum SwitchType
{
    Linear,
    Tactile,
    Clicky
}
public enum MonitorResolution
{
    R1080p,
    R1440p,
    R2160p 
}

public enum RefreshRate
{
    R60Hz,
    R120Hz,
    R144Hz,
    R180Hz,
    R240Hz,
    R360Hz
}

public enum EfficiencyRating
{
    Bronze,
    Silver,
    Gold,
    Platinum,
    Titanium
}

public enum ChassiMaterial
{
    Steel,
    Aluminum,
    Plastic,
    TemperedGlass
}

public enum VRAMType
{
    GDDR5,
    GDDR5X,
    GDDR6,
    GDDR6X,
    HBM2,
    HBM2E
}
