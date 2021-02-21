using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MundoBalloonApi.graphql.Middleware;
using MundoBalloonApi.graphql.Products;
using MundoBalloonApi.graphql.Types;

namespace MundoBalloonApi.graphql
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // If you need dependency injection with your query object add your query type as a services.
            // services.AddSingleton<Query>();

            // enable InMemory messaging services for subscription support.
            // services.AddInMemorySubscriptions();

            // this enables you to use DataLoader in your resolvers.
            // services.AddDataLoaderRegistry();

            ServicesDataStartup.ConfigureServices(services);
            ServicesAuthenticationStartup.ConfigureServices(services, Configuration);

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<ProductsQueries>()
                .AddType<ProductType>()
                .AddType<ProductCategoryType>()
                .AddType<ProductVariantType>()
                .AddAuthorization()
                .AddHttpRequestInterceptor(AuthenticationInterceptor.GetAuthenticationInterceptor());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
        }
    }
}