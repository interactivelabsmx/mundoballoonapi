using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MundoBalloonApi.graphql
{
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
                });
            return services;
        }
    }
}