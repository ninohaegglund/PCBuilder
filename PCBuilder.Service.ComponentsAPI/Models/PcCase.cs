namespace PCBuilder.Service.ComponentsAPI.Models
{
    public class PcCase
    {
        public string name { get; set; } = string.Empty;
        public decimal price { get; set; }
        public string type { get; set; } = string.Empty;
        public string color { get; set; } = string.Empty;
        public string? psu { get; set; }
        public string side_panel { get; set; } = string.Empty;
        public int? external_volume { get; set; }
        public int @internal_35_bays { get; set; }
    }
}
