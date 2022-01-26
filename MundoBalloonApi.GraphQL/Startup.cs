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

        // If you need dependency injection with your query object add your query type as a services.
        // services.AddSingleton<Query>();

        // enable InMemory messaging services for subscription support.
        // services.AddInMemorySubscriptions();

        // this enables you to use DataLoader in your resolvers.
        // services.AddDataLoaderRegistry();
        var connectionString =
            new MySqlConnectionStringBuilder(Environment.GetEnvironmentVariable("MUNDOB_DB_STR") ?? "").ToString();

        services.AddMundoBServices()
            .AddHttpContextAccessor()
            .AddAutoMapper(typeof(EntitiesMappingProfile))
            .AddDbServices(Configuration, connectionString)
            .AddAuthenticationServices()
            .AddInputValidationServices();

        services
            .AddGraphQLServer()
            .AddQueryType(d => d.Name("Query"))
            .AddTypeExtension<UserQueries>()
            .AddTypeExtension<SiteQueries>()
            .AddTypeExtension<ProductQueries>()
            .AddTypeExtension<CollectionQueries>()
            .AddMutationType(d => d.Name("Mutation"))
            .AddTypeExtension<UserMutations>()
            .AddTypeExtension<ProductMutations>()
            .AddSorting()
            .AddAuthorization()
            .AddHttpRequestInterceptor(AuthenticationInterceptor.GetAuthenticationInterceptor());

        var origins = new[] { "https://dev.mundoballoon.com", "https://dev.mundoballoon.com:3000" };
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins(origins)
                    .AllowAnyHeader()
                    .AllowAnyHeader();
            });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseAuthentication();

        app.UseRouting();

        if (env.IsDevelopment()) app.UseCors();

        app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
    }
}