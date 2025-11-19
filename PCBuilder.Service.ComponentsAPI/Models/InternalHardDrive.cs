namespace PCBuilder.Service.ComponentsAPI.Models;

public class InternalHardDrive
{
  
    public string name { get; set; } = null!;
    public decimal price { get; set; }
    public int capacity { get; set; }
    public decimal price_per_gb { get; set; }
    public string type { get; set; } = null!;
    public int? cache { get; set; }
    public string formfactor { get; set; } = null!;
    public string @interface { get; set; } = null!;
                                    
}
