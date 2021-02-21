using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.Services;
using MundoBalloonApi.infrastructure.Data.Models;
using MySqlConnector;

namespace MundoBalloonApi.graphql
{
    public static class ServicesDataStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            var connectionString =
                new MySqlConnectionStringBuilder(Environment.GetEnvironmentVariable("MUNDOB_DB_STR") ?? "");
            services.AddPooledDbContextFactory<MundoBalloonContext>(options =>
                options.UseMySql(connectionString.ToString(), new MySqlServerVersion(new Version(8, 0, 23))));
        }
    }
}