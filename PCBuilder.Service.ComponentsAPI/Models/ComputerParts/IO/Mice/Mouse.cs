namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Mice
{
    public class Mouse
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int Dpi { get; set; }
        public bool IsWireless { get; set; }
        public int NumberOfButtons { get; set; }
    }
}
