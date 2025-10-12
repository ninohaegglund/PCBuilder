using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Web.Service;
using PCBuilder.Web.Service.IService;
using PCBuilder.Web.Utility;
using PCBuilder.Service.BuilderServiceAPI.Data;
using PCBuilder.Service.BuilderServiceAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICouponService,CouponService>();
SD.CouponAPIBase = builder.Configuration["ServiceUrls:CouponAPI"]!;


builder.Services.AddDbContext<PcDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IComponentService, ComponentService>();



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
