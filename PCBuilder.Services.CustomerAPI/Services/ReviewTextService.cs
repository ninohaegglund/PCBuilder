using PCBuilder.Services.CustomerAPI.IServices;
using System.Text.Json;

namespace PCBuilder.Services.CustomerAPI.Services;

public class ReviewTextService : IReviewTextService
{
    private readonly Dictionary<string, List<string>> _texts;
    private readonly Random _random = new();

    public ReviewTextService(IWebHostEnvironment env)
    {
        var filePath = Path.Combine(env.ContentRootPath, "Data", "ReviewText.json");

        if (!File.Exists(filePath))
        {
            _texts = new Dictionary<string, List<string>>();
            return;
        }

        var json = File.ReadAllText(filePath);

        _texts = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(
                     json,
                     new JsonSerializerOptions
                     {
                         PropertyNameCaseInsensitive = true
                     })
                 ?? new Dictionary<string, List<string>>();
    }

    public string GetRandomText(string key)
    {
        if (!_texts.TryGetValue(key, out var texts) || texts.Count == 0)
        {
            return string.Empty;
        }

        return texts[_random.Next(texts.Count)];
    }
}