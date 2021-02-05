using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MundoBalloonApi.web
{
    public static class ServicesSwaggerStartup
    {
        private const string Version = "v1";
        private const ParameterLocation In = ParameterLocation.Header;
        private const SecuritySchemeType Type = SecuritySchemeType.ApiKey;
        private const string Name = "Authorization";
        public const string Title = "MundoBalloon API V1";
        public const string Path = "/swagger/v1/swagger.json";

        private const string Description =
            "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"";

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Version, new OpenApiInfo {Title = Title, Version = Version});
                c.EnableAnnotations();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = In,
                    Type = Type,
                    Name = Name,
                    Description = Description
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        new[] {"readAccess", "writeAccess"}
                    }
                });
            });
        }
    }
}