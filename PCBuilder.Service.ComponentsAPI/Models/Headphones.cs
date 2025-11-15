namespace PCBuilder.Service.ComponentsAPI.Models
{
    public class Headphones
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public string type { get; set; } 
        public int[] frequency_response { get; set; }
        public bool microphone { get; set; }
        public bool wireless { get; set; }
        public string enclosure_type { get; set; }
        public string color { get; set; }
    }
}
