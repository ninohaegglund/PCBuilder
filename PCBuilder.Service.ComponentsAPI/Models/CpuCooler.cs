using System.Text.Json;

namespace PCBuilder.Service.ComponentsAPI.Models;

public class CpuCooler
{
    public string? name { get; set; }
    public decimal? price { get; set; }

    public JsonElement rpm { get; set; }

    public decimal? noise_level { get; set; }
    public string? color { get; set; }

    public string? size { get; set; }

    public bool HasRpmRange =>
        rpm.ValueKind == JsonValueKind.Array && rpm.GetArrayLength() == 2;

    public (int min, int max)? GetRpmRange()
    {
        if (!HasRpmRange) return null;
        var min = rpm[0].GetInt32();
        var max = rpm[1].GetInt32();
        return (min, max);
    }

    public int? GetSingleRpm()
    {
        return rpm.ValueKind == JsonValueKind.Number ? rpm.GetInt32() : null;
    }
}
