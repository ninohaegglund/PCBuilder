namespace PCBuilder.Service.ComponentsAPI.Models;

public class CaseFan
{
    public string Name { get; set; } = null!;
    public decimal? Price { get; set; }           
    public int Size { get; set; }                 
    public string Color { get; set; } = null!;             
    public string? Rpm { get; set; }            
    public string? Airflow { get; set; }       
    public string? NoiseLevel { get; set; }       
    public bool Pwm { get; set; }                 
}
