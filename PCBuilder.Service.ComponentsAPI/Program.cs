using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.ComponentsAPI;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.IRepositories;
using PCBuilder.Service.ComponentsAPI.Mapping;
using PCBuilder.Service.ComponentsAPI.Repositories;
using PCBuilder.Service.ComponentsAPI.Services;
using PCBuilder.Services.ComponentsAPI.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddScoped<IComponentService, ComponentService>();
builder.Services.AddScoped<IComponentRepository, ComponentRepository>();

builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.SaveChanges();
}

app.Run();
