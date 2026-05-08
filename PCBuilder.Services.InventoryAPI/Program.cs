using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.InventoryAPI.Data;
using PCBuilder.Services.InventoryAPI.IRepository;
using PCBuilder.Services.InventoryAPI.IServices;
using PCBuilder.Services.InventoryAPI.Repositories;
using PCBuilder.Services.InventoryAPI.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
object value = builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
