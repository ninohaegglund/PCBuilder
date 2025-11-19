namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;
public class AllComponentsDto
{
    public List<Cpu> Cpus { get; set; } = new();
    public List<VideoCard> Gpus { get; set; } = new();
    public List<MemoryKit> Rams { get; set; } = new();
    public List<Motherboard> Motherboards { get; set; } = new();
    public List<Case> Cases { get; set; } = new();
    public List<PowerSupply> Psus { get; set; } = new();
    public List<CpuCooler> CpuCoolers { get; set; } = new();
    public List<CaseFan> CaseFans { get; set; } = new();
    public List<InternalHardDrive> InternalStorages { get; set; } = new();
    public List<ExternalHardDrive> ExternalStorages { get; set; } = new();
    public List<Monitor> Monitors { get; set; } = new();
    public List<Keyboard> Keyboards { get; set; } = new();
    public List<Mouse> Mice { get; set; } = new();
    public List<Headphones> Headphones { get; set; } = new();
    public List<Speakers> Speakers { get; set; } = new();
    public List<Webcam> Webcams { get; set; } = new();
    public List<FanController> FanControllers { get; set; } = new();
    public List<SoundCard> SoundCards { get; set; } = new();
    public List<Ups> Ups { get; set; } = new();
    public List<OperatingSystem> OperatingSystems { get; set; } = new();
    public List<CaseAccessory> CaseAccessories { get; set; } = new();
}
