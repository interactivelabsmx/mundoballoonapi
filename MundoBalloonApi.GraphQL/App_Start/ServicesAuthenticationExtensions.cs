using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MundoBalloonApi.business.Contracts;

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
                        var usersService = context.HttpContext.RequestServices.GetRequiredService<IUsersService>();
                        // TODO: Add claims from firebase
                        // var userClaims = usersService.GetUserClaims(userId);
                        // var claims = userClaims.ConvertAll(UserClaimConverter);
                        // var appIdentity = new ClaimsIdentity(claims);
                        // context.Principal?.AddIdentity(appIdentity);
                        return Task.CompletedTask;
                    }
                };
            });
        return services;
    }

    // private static Claim UserClaimConverter(UserClaim userClaim)
    // {
    //     var claim = userClaim.Claim?.Claim1 ?? "";
    //     return new Claim(claim, "true");
    // }
}