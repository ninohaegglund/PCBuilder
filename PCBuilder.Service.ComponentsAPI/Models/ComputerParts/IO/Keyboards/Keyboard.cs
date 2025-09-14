using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Keyboards
{
    public class Keyboard
    {
        public int KeyboardId { get; set; }
        public string ModelName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;

        public bool IsMechanical { get; set; }
        public SwitchType SwitchType { get; set; }
        public bool IsWireless { get; set; }
        public bool HasBacklight { get; set; }
        public string Layout { get; set; } = null!;
        public int SizePercent { get; set; }
    }
}