using System;
using EFCoreSecondLevelCacheInterceptor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.Services;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.infrastructure.Data.Repositories;

namespace MundoBalloonApi.graphql
{
    public static class ServicesDataStartupExtensions
    {
        private const string CacheProviderName = "MundoBCache";

        public static IServiceCollection AddMundoBServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IUsersService, UsersService>()
                .AddScoped<ISiteService, SiteService>();
        }

        public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration,
            string connectionString)
        {
            return services.AddPooledDbContextFactory<MundoBalloonContext>((serviceProvider, options) =>
                    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23)))
                        .AddInterceptors(serviceProvider.GetRequiredService<SecondLevelCacheInterceptor>()))
                .AddEFSecondLevelCache(options =>
                {
                    options.UseEasyCachingCoreProvider(CacheProviderName);
                    options.CacheAllQueries(CacheExpirationMode.Sliding, TimeSpan.FromMinutes(15));
                })
                .AddEasyCaching(options => { options.WithJson().UseRedis(configuration, CacheProviderName); });
        }
    }
}