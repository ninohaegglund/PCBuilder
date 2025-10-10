using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCBuilder.Service.BuilderServiceAPI.Models;

public class PcDataContext : DbContext
{
    public PcDataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Computer> Computers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType.IsEnum)
                {
                    var converterType = typeof(EnumToStringConverter<>).MakeGenericType(property.ClrType);
                    var converter = Activator.CreateInstance(converterType) as ValueConverter;
                    property.SetValueConverter(converter);
                }
            }
        }

    }
}