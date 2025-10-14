using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.BuilderServiceAPI.Client;
using PCBuilder.Service.BuilderServiceAPI.Data;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IRepository;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Repository;
using PCBuilder.Service.BuilderServiceAPI.Services;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.IRepositories;
using PCBuilder.Service.ComponentsAPI.Repositories;
using PCBuilder.Service.ComponentsAPI.Services;
using PCBuilder.Web.Service;
using PCBuilder.Web.Service.IService;
using PCBuilder.Web.Utility;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICouponService,CouponService>();
builder.Services.AddHttpClient<ComponentsAPIClient>();
SD.CouponAPIBase = builder.Configuration["ServiceUrls:CouponAPI"]!;


builder.Services.AddDbContext<BuildDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IComponentService, ComponentService>();
builder.Services.AddScoped<IComponentRepository, ComponentRepository>();
builder.Services.AddScoped<IInventoryItemService, InventoryItemService>();
builder.Services.AddScoped<IGetComponentsService, GetComponentsService>();
builder.Services.AddScoped<IBuilderBaseService, BuilderBaseService>();
builder.Services.AddScoped<ComputerCreateDTO>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));




var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
