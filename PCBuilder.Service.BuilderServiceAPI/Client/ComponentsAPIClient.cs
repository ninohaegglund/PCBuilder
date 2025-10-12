namespace PCBuilder.Service.BuilderServiceAPI.Client;

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
        if (ids == null || !ids.Any())
            return new List<T>();

        var idString = string.Join(",", ids);
        var response = await _http.GetAsync($"{endpoint}?ids={idString}");
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<List<T>>(stream, _jsonOptions);
        return result ?? new List<T>();
    }
}
