using PCBuilder.Web.Service;
using PCBuilder.Web.Service.IService;
using PCBuilder.Web.Utility;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICouponService,CouponService>();
SD.CouponAPIBase = builder.Configuration["ServiceUrls:CouponAPI"]!;     
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICouponService, CouponService>();

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
