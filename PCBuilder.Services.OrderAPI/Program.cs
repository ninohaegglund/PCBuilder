using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.OrderAPI;
using PCBuilder.Services.OrderAPI.Data;
using PCBuilder.Services.OrderAPI.IRepository;
using PCBuilder.Services.OrderAPI.IService;
using PCBuilder.Services.OrderAPI.Models;
using PCBuilder.Services.OrderAPI.Repositories;
using PCBuilder.Services.OrderAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));




var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
ApplyMigrations();

app.Run();

void ApplyMigrations()
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
    if (dbContext.Database.GetPendingMigrations().Count() > 0)
    {
        dbContext.Database.Migrate();
    }
}
