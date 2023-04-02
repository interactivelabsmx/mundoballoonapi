using EFCoreSecondLevelCacheInterceptor;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.Services;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.infrastructure.Data.Repositories;

namespace MundoBalloonApi.graphql;

public static class ServicesDataStartupExtensions
{
    private const string CacheProviderName = "MundoBCache";

    public static IServiceCollection AddMundoBServices(this IServiceCollection services)
    {
        return services
            .AddScoped<ICollectionsRepository, CollectionsRepository>()
            .AddScoped<IOrdersRepository, OrdersRepository>()
            .AddScoped<IProductsRepository, ProductsRepository>()
            .AddScoped<IUsersRepository, UsersRepository>()
            .AddScoped<ICollectionsService, CollectionsService>()
            .AddScoped<IOrdersService, OrdersService>()
            .AddScoped<IPaymentsService, PaymentsService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<ISiteService, SiteService>()
            .AddScoped<IUsersService, UsersService>();
    }

    public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration,
        string connectionString)
    {
        return services.AddPooledDbContextFactory<MundoBalloonContext>((serviceProvider, options) =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29)))
                    .AddInterceptors(serviceProvider.GetRequiredService<SecondLevelCacheInterceptor>()))
            .AddEFSecondLevelCache(options =>
            {
                options.UseEasyCachingCoreProvider(CacheProviderName);
                options.CacheAllQueries(CacheExpirationMode.Sliding, TimeSpan.FromMinutes(15));
            })
            .AddEasyCaching(options => { options.WithJson().UseRedis(configuration, CacheProviderName); });
    }
}