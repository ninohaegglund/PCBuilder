using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.BuilderServiceAPI.Client;
using PCBuilder.Service.BuilderServiceAPI.Data;
using PCBuilder.Service.BuilderServiceAPI.IRepository;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Repository;
using PCBuilder.Service.BuilderServiceAPI.Services;
using PCBuilder.Service.BuilderServiceAPI.Utility;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ComponentsAPIClient>();
SD.InventoryAPIBase = builder.Configuration["ServiceUrls:InventoryAPI"]!;

builder.Services.AddDbContext<BuildDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IGetComponentsService, GetComponentsService>();
builder.Services.AddScoped<IBuilderBaseService, BuilderBaseService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
