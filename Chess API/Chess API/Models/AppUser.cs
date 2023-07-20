using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser<int>
{
    public int AppUserId { get; set; }

    public List<string> Roles { get; set; }

    public AppUser()
    {
        // Default constructor needed for Identity framework
    }

    public AppUser(int appUserId, string username, List<string> roles)
    {
        AppUserId = appUserId;
        UserName = username;
        Roles = roles;
    }

    public List<Claim> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, AppUserId.ToString()),
            new Claim(ClaimTypes.Name, UserName),
        };

        foreach (var role in Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }

    public static List<string> ConvertAuthoritiesToRoles(IEnumerable<Claim> claims)
    {
        return claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();
    }
}
