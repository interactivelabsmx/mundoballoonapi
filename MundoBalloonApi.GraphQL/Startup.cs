using AspNetCoreRateLimit.Redis;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using MundoBalloonApi.business.Middleware;
using MundoBalloonApi.graphql.Collections;
using MundoBalloonApi.graphql.Middleware;
using MundoBalloonApi.graphql.Orders;
using MundoBalloonApi.graphql.Payments;
using MundoBalloonApi.graphql.Products;
using MundoBalloonApi.graphql.Site;
using MundoBalloonApi.graphql.Users;
using MundoBalloonApi.infrastructure.Data.Models;
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
        var firebaseCredentialString = Environment.GetEnvironmentVariable("FIREBASE_PRIVATE_KEY") ?? "";
        var logConnectionString = Environment.GetEnvironmentVariable("MUNDOB_LOG_STR") ?? "";
        var connectionString =
            new MySqlConnectionStringBuilder(Environment.GetEnvironmentVariable("MUNDOB_DB_STR") ?? "").ToString();

        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromJson(firebaseCredentialString)
        });

        services.AddMundoBServices()
            .AddAutoMapper(typeof(EntitiesMappingProfile))
            .AddDbServices(Configuration, connectionString)
            .AddHttpContextAccessor()
            .AddAuthenticationServices()
            .AddAuthorization()
            .AddRedisRateLimiting();

        services
            .AddGraphQLServer()
            .RegisterDbContext<MundoBalloonContext>(DbContextKind.Pooled)
            .AddAuthorization()
            .AddHttpRequestInterceptor(HttpRequestInterceptor.GetHttpRequestInterceptorDelegate())
            .AddType<UploadType>()
            .AddQueryType()
            .AddTypeExtension<SiteQueries>()
            .AddTypeExtension<UserQueries>()
            .AddTypeExtension<UserEventQueries>()
            .AddTypeExtension<UserCartQueries>()
            .AddTypeExtension<OrderQueries>()
            .AddTypeExtension<ProductQueries>()
            .AddTypeExtension<CollectionQueries>()
            .AddMutationType()
            .AddTypeExtension<UserMutations>()
            .AddTypeExtension<UserCartMutations>()
            .AddTypeExtension<UserEventMutations>()
            .AddTypeExtension<OrderMutations>()
            .AddTypeExtension<ProductMutations>()
            .AddTypeExtension<CollectionMutations>()
            .AddTypeExtension<PaymentsMutations>()
            .AddSorting()
            .AddFiltering()
            .AddInstrumentation();

        services
            .AddOpenTelemetryLogging(logConnectionString)
            .AddCorsServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        if (!env.IsDevelopment()) app.UseHsts();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        if (env.IsDevelopment()) app.UseCors();

        app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
    }
}