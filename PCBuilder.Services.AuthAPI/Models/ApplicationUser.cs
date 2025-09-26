using Microsoft.AspNetCore.Identity;

namespace PCBuilder.Services.AuthAPI.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}
