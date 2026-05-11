using PCBuilder.Services.CustomerAPI.Models;
using System.Text.Json;

namespace PCBuilder.Services.CustomerAPI.Data;

public static class DbSeederOrder
{
    public static void SeedOrders(CustomerDbContext context)
    {
        var customers = context.Customers
            .OrderBy(x => x.Id)
            .ToList();

        if (!customers.Any())
        {
            return;
        }

        var prompts = LoadPrompts();
        var existingDescriptions = context.Orders
            .Select(x => x.Description)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        var createdAt = DateTime.UtcNow.AddDays(-prompts.Count);

        for (var index = 0; index < prompts.Count; index++)
        {
            var prompt = prompts[index];
            if (existingDescriptions.Contains(prompt.Description))
            {
                continue;
            }

            var customer = customers[index % customers.Count];

            context.Orders.Add(new Order
            {
                CustomerId = customer.Id,
                Budget = prompt.Budget,
                Description = prompt.Description,
                DetailedDescription = prompt.DetailedDescription,
                Status = OrderStatus.Pending,
                CreatedAt = createdAt.AddHours(index)
            });
        }

        context.SaveChanges();
    }

    private static List<OrderPromptSeed> LoadPrompts()
    {
        var projectRoot = FindProjectRoot("PCBuilder.Services.CustomerAPI") ?? Directory.GetCurrentDirectory();
        var jsonPath = Path.Combine(projectRoot, "Data", "OrderPrompts.json");

        if (!File.Exists(jsonPath))
        {
            return FallbackPrompts();
        }

        var jsonText = File.ReadAllText(jsonPath);
        return JsonSerializer.Deserialize<List<OrderPromptSeed>>(
            jsonText,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? FallbackPrompts();
    }

    private static string? FindProjectRoot(string targetProjectFolderName)
    {
        var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (dir != null)
        {
            var candidate = Path.Combine(dir.FullName, targetProjectFolderName);
            if (Directory.Exists(candidate))
            {
                return candidate;
            }

            dir = dir.Parent;
        }

        return null;
    }

    private static List<OrderPromptSeed> FallbackPrompts()
    {
        return new List<OrderPromptSeed>
        {
            new()
            {
                Description = "Starter esports PC",
                DetailedDescription = "I need a balanced first gaming PC for 1080p esports. Please keep it affordable and stable.",
                Budget = 10500m
            },
            new()
            {
                Description = "Quiet home office PC",
                DetailedDescription = "I need a quiet and dependable computer for work, school, and everyday use.",
                Budget = 12000m
            },
            new()
            {
                Description = "Mid-range gaming upgrade",
                DetailedDescription = "I want a stronger 1080p gaming PC with sensible cooling and enough PSU headroom.",
                Budget = 22000m
            }
        };
    }

    private sealed class OrderPromptSeed
    {
        public string Description { get; set; } = string.Empty;
        public string DetailedDescription { get; set; } = string.Empty;
        public decimal Budget { get; set; }
    }
}
