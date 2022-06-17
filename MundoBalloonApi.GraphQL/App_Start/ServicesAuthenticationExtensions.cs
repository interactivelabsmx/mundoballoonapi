using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MundoBalloonApi.graphql;

public static class ServicesAuthenticationExtensions
{
    public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://securetoken.google.com/mundoballoon-dev";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://securetoken.google.com/mundoballoon-dev",
                    ValidateAudience = true,
                    ValidAudience = "mundoballoon-dev",
                    ValidateLifetime = true
                };
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userId = context.Principal.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
                        var role = context.Principal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
                        var claims = new List<Claim>()
                        {
                            role ?? new Claim(ClaimTypes.Role, "USER")
                        };
                        var appIdentity = new ClaimsIdentity(claims);
                        context.Principal?.AddIdentity(appIdentity);
                        return Task.CompletedTask;
                    }
                };
            });
        return services;
    }
}