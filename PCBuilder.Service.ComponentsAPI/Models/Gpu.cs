namespace PCBuilder.Service.ComponentsAPI.Models;

public class Gpu
{
    public string name { get; set; } = null!;
    public double price { get; set; }        
    public string chipset { get; set; } = null!;
    public int memory { get; set; }            
    public int core_clock { get; set; }       
    public int boost_clock { get; set; }      
    public string color { get; set; } = null!;
    public int length { get; set; }         
}
