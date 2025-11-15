namespace PCBuilder.Service.ComponentsAPI.Models
{
    public class Webcam
    {
        public string name { get; set; } = null!;

        public decimal price { get; set; }

        public List<string> resolutions { get; set; }

        public string connection { get; set; } = null!;

        public string focus_type { get; set; } = null!;

        public List<string> os { get; set; }

        public int fov { get; set; }
    }
}
