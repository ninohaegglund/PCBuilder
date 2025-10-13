using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.BuilderServiceAPI;
using PCBuilder.Service.BuilderServiceAPI.Client;
using PCBuilder.Service.BuilderServiceAPI.Data;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IRepository;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Mapping;
using PCBuilder.Service.BuilderServiceAPI.Repository;
using PCBuilder.Service.BuilderServiceAPI.Services;
using PCBuilder.Service.BuilderServiceAPI.Utility;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IInventoryService, InventoryService>();
builder.Services.AddHttpClient<ComponentsAPIClient>();
SD.InventoryAPIBase = builder.Configuration["ServiceUrls:InventoryAPI"]!;

builder.Services.AddDbContext<PcDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddControllers();
builder.Services.AddSingleton(mapper);
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IGetComponentsService, GetComponentsService>();
builder.Services.AddScoped<IBuilderBaseService, BuilderBaseService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<ComputerCreateDTO>();
builder.Services.AddScoped<IBuiltComputersRepository, ComputersRepository>();
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
    var dbContext = scope.ServiceProvider.GetRequiredService<PcDataContext>();
    if (dbContext.Database.GetPendingMigrations().Count() > 0)
    {
        dbContext.Database.Migrate();
    }
}