using System.Text.Json.Serialization;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.PSUs;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Motherboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Chassi;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Keyboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Mice;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Headsets;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.RAM;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.StorageDevice;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Speakers;

namespace PCBuilder.Service.ComponentsAPI.Models
{

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(CPU), "CPU")]
    [JsonDerivedType(typeof(PSU), "PSU")]
    [JsonDerivedType(typeof(Motherboard), "Motherboard")]
    [JsonDerivedType(typeof(Chassi), "Chassi")]
    [JsonDerivedType(typeof(CPUCooling), "CPUCooling")]
    [JsonDerivedType(typeof(Keyboard), "Keyboard")]
    [JsonDerivedType(typeof(Mouse), "Mouse")]
    [JsonDerivedType(typeof(Headset), "Headset")]
    [JsonDerivedType(typeof(GPU), "GPU")]
    [JsonDerivedType(typeof(RAM), "RAM")]
    [JsonDerivedType(typeof(StorageDevice), "StorageDevice")]
    [JsonDerivedType(typeof(ChassiCooling), "ChassiCooling")]
    [JsonDerivedType(typeof(DisplayMonitor), "DisplayMonitor")]
    [JsonDerivedType(typeof(Speaker), "Speaker")]
    [JsonDerivedType(typeof(NvidiaGpu), "NvidiaGpu")]
    [JsonDerivedType(typeof(AmdGpu), "AmdGpu")]
    [JsonDerivedType(typeof(AtxMotherboard), "AtxMotherboard")]
    [JsonDerivedType(typeof(MicroAtxMotherboard), "MicroAtxMotherboard")]
    [JsonDerivedType(typeof(MiniItxMotherboard), "MiniItxMotherboard")]
    public class Components
    {
        public int Id { get; set; }
    }
}