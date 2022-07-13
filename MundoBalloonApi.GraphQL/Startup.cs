using AspNetCoreRateLimit.Redis;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using MundoBalloonApi.business.Middleware;
using MundoBalloonApi.graphql.Collections;
using MundoBalloonApi.graphql.Middleware;
using MundoBalloonApi.graphql.Products;
using MundoBalloonApi.graphql.Site;
using MundoBalloonApi.graphql.Users;
using MySqlConnector;

namespace MundoBalloonApi.graphql;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromJson(Environment.GetEnvironmentVariable("FIREBASE_PRIVATE_KEY") ?? "")
        });

        var connectionString =
            new MySqlConnectionStringBuilder(Environment.GetEnvironmentVariable("MUNDOB_DB_STR") ?? "").ToString();

        services.AddMundoBServices()
            .AddAutoMapper(typeof(EntitiesMappingProfile))
            .AddDbServices(Configuration, connectionString)
            .AddHttpContextAccessor()
            .AddInputValidationServices()
            .AddAuthenticationServices()
            .AddRedisRateLimiting();

        services
            .AddGraphQLServer()
            .AddType<UploadType>()
            .AddQueryType(d => d.Name("Query"))
            .AddTypeExtension<SiteQueries>()
            .AddTypeExtension<UserQueries>()
            .AddTypeExtension<ProductQueries>()
            .AddTypeExtension<CollectionQueries>()
            .AddMutationType(d => d.Name("Mutation"))
            .AddTypeExtension<UserMutations>()
            .AddTypeExtension<ProductMutations>()
            .AddTypeExtension<CollectionMutations>()
            .AddSorting()
            .AddAuthorization()
            .AddHttpRequestInterceptor(AuthenticationInterceptor.GetAuthenticationInterceptor())
            .AddInstrumentation();

        var logConnectionString = Environment.GetEnvironmentVariable("MUNDOB_LOG_STR") ?? "";
        services.AddOpenTelemetryLogging(logConnectionString);
        
        services.AddCorsServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        if (!env.IsDevelopment()) app.UseHsts();

        app.UseAuthentication();

        app.UseRouting();

        if (env.IsDevelopment()) app.UseCors();

        app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
    }
}