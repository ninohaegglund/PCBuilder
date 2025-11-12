namespace PCBuilder.Service.BuilderServiceAPI.Client;

using System;
using System.Net.Http;
using System.Text.Json;

public class ComponentsAPIClient
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

    public ComponentsAPIClient(HttpClient http)
    {
        _http = http;   
    }

    public async Task<List<T>> GetByIdsAsync<T>(string endpoint, IEnumerable<int> ids)
    {
        var results = new List<T>();
        if (ids == null || !ids.Any()) return results;

        foreach (var id in ids)
        {
            var response = await _http.GetAsync($"{endpoint}/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(json))
                continue;

            var trimmed = json.TrimStart();

            if (trimmed.StartsWith("["))
            {
                var list = JsonSerializer.Deserialize<List<T>>(json, _jsonOptions);
                if (list != null)
                    results.AddRange(list);
            }
            else
            {
                var item = JsonSerializer.Deserialize<T>(json, _jsonOptions);
                if (item != null)
                    results.Add(item);
            }
        }

        return results;
    }
}
