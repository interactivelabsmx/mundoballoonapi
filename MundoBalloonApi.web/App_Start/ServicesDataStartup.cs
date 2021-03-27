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
using MySqlConnector;

namespace MundoBalloonApi.web
{
    public static class ServicesDataStartup
    {
        private const string CacheProviderName = "MundoBCache";

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ISiteService, SiteService>();

            var connectionString =
                new MySqlConnectionStringBuilder(Environment.GetEnvironmentVariable("MUNDOB_DB_STR") ?? "");
            services.AddPooledDbContextFactory<MundoBalloonContext>((serviceProvider, options) =>
                    options.UseMySql(connectionString.ToString(), new MySqlServerVersion(new Version(8, 0, 23)))
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