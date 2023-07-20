using System.Security.Claims;
using System.Text.Encodings.Web;
using Chess_API.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class JwtAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly JwtConverter _converter;

    public JwtAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        JwtConverter converter)
        : base(options, logger, encoder, clock)
    {
        _converter = converter;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authorization = Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(authorization) && authorization.ToString().StartsWith("Bearer "))
        {
            var token = authorization.ToString().Substring("Bearer ".Length);
            var appUser = _converter.GetUserFromToken(token);
            if (appUser != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, appUser.AppUserId.ToString()),
                    new Claim(ClaimTypes.Name, appUser.UserName),
                };
                foreach (var role in appUser.Roles)
                {
                    claims.Append(new Claim(ClaimTypes.Role, role));
                }

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("Invalid token.");
            }
        }

        return AuthenticateResult.NoResult();
    }
}
