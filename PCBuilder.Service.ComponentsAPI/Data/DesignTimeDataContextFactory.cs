using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PCBuilder.Services.ComponentsAPI.Data;

namespace PCBuilder.Service.ComponentsAPI.Data
{
    public class DesignTimeDataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var cs = config.GetConnectionString("DefaultConnection")
                     ?? throw new InvalidOperationException("DefaultConnection is missing.");

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(cs)
                .Options;

            return new DataContext(options);
        }
    }
}