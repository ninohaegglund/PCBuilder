
using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.IdentityAPI.Data;
using PCBuilder.Services.IdentityAPI.Interfaces;
using PCBuilder.Services.IdentityAPI.JWT;
using PCBuilder.Services.IdentityAPI.Repositories;
using PCBuilder.Services.IdentityAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

IServiceCollection serviceCollection = builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
object value = builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
    await dbContext.Database.MigrateAsync();
    await DbSeeder.SeedAsync(dbContext);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();