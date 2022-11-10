using AspNetCoreRateLimit.Redis;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using MundoBalloonApi.business.Middleware;
using MundoBalloonApi.graphql.Collections;
using MundoBalloonApi.graphql.Middleware;
using MundoBalloonApi.graphql.Products;
using MundoBalloonApi.graphql.Site;
using MundoBalloonApi.graphql.Users;

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
        var firebaseCredentialString = Environment.GetEnvironmentVariable("FIREBASE_PRIVATE_KEY") ?? "";
        var logConnectionString = Environment.GetEnvironmentVariable("MUNDOB_LOG_STR") ?? "";
        var connectionString = Environment.GetEnvironmentVariable("MUNDOB_DB_STR_MS") ?? "";

        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromJson(firebaseCredentialString)
        });

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
            .AddQueryType()
            .AddTypeExtension<SiteQueries>()
            .AddTypeExtension<UserQueries>()
            .AddTypeExtension<UserEventQueries>()
            .AddTypeExtension<ProductQueries>()
            .AddTypeExtension<CollectionQueries>()
            .AddMutationType()
            .AddTypeExtension<UserMutations>()
            .AddTypeExtension<UserEventMutations>()
            .AddTypeExtension<ProductMutations>()
            .AddTypeExtension<CollectionMutations>()
            .AddSorting()
            .AddFiltering()
            .AddAuthorization()
            .AddHttpRequestInterceptor(HttpRequestInterceptor.GetHttpRequestInterceptorDelegate())
            .AddInstrumentation();

        services
            .AddOpenTelemetryLogging(logConnectionString)
            .AddCorsServices();
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