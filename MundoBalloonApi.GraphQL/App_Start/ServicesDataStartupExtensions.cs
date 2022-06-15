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

    public static IServiceCollection AddMundoBServices(this IServiceCollection services) =>
     services
            .AddScoped<IUsersRepository, UsersRepository>()
            .AddScoped<IProductsRepository, ProductsRepository>()
            .AddScoped<ICollectionsRepository, CollectionsRepository>()
            .AddScoped<IUsersService, UsersService>()
            .AddScoped<ISiteService, SiteService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<ICollectionsService, CollectionsService>();

    public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration,
        string connectionString) => services.AddPooledDbContextFactory<MundoBalloonContext>((serviceProvider, options) =>
            {
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29)))
                    .AddInterceptors(serviceProvider.GetRequiredService<SecondLevelCacheInterceptor>());
                options.EnableSensitiveDataLogging();
            })
            .AddEFSecondLevelCache(options =>
            {
                options.UseEasyCachingCoreProvider(CacheProviderName);
                options.CacheAllQueries(CacheExpirationMode.Sliding, TimeSpan.FromMinutes(15));
            })
            .AddEasyCaching(options => { options.WithJson().UseRedis(configuration, CacheProviderName); });
}