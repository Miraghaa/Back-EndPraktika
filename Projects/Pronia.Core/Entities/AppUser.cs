using Microsoft.AspNetCore.Identity;

namespace Pronia.Core.Entities;

public class AppUser:IdentityUser
{
    public string Fullname { get; set; } = null!;
}
