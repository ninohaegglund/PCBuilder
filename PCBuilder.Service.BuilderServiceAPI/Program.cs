using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Service.ComponentsAPI.Services;
using PCBuilder.Service.ComponentsAPI.Services.IService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<ComputerCreateDTO>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
