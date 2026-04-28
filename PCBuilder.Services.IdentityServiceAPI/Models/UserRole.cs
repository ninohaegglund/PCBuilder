namespace PCBuilder.Services.IdentityAPI.Models;

public class UserRole
{
    public Guid UserId { get; set; }
    public IdentityUser User { get; set; } = null!;

    public Guid RoleId { get; set; }
    public Role Role { get; set; } = null!;
}
