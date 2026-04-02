using PCBuilder.Services.CustomerAPI.Models;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace PCBuilder.Services.CustomerAPI.Data;

public class DbSeederCustomer
{
    public static void SeedCustomers(CustomerDbContext context)
    {
        if (context.Customers.Any()) return;

        var webProjectRoot = FindProjectRoot("PCBuilder.Web") ?? Directory.GetCurrentDirectory();
        var imageFolder = Path.Combine(webProjectRoot, "wwwroot", "images", "customers");
        var urlPath = webProjectRoot.Replace('\\', '/');
        var imageFiles = Directory.GetFiles(imageFolder, "*.png").ToList();

        var jsonPath = Path.Combine(webProjectRoot, "wwwroot", "images", "customers", "names.json");
        var jsonText = File.ReadAllText(jsonPath);
        var names = JsonSerializer.Deserialize<List<string>>(jsonText) ?? new List<string>();

        var random = new Random();

        foreach (var image in imageFiles)
        {
            string name;
            if (names.Count > 0)
            {
                var index = random.Next(names.Count);
                name = names[index];
                names.RemoveAt(index); 
            }
            else
            {
                name = "Unknown Customer";
            }

            var relativePath = $"/images/customers/{Path.GetFileName(image)}";
            context.Customers.Add(new Customer
            {
                Name = name,
                ImageUrl = relativePath
            });
        }

        context.SaveChanges();
    }

    private static string? FindProjectRoot(string targetProjectFolderName)
    {
        var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (dir != null)
        {
            var candidate = Path.Combine(dir.FullName, targetProjectFolderName);
            if (Directory.Exists(candidate))
                return candidate;

            dir = dir.Parent;
        }

        return null;
    }
}
