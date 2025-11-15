namespace PCBuilder.Service.ComponentsAPI.Models;

public class SoundCard
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public double Channels { get; set; }       
    public int Digital_audio { get; set; }     
    public int Snr { get; set; }              
    public int Sample_rate { get; set; }       
    public string Chipset { get; set; }
    public string Interface { get; set; }
}


public class SoundCardList
{
    public List<SoundCard> Items { get; set; }
}


