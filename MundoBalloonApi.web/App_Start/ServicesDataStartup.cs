using System;
using Microsoft.EntityFrameworkCore;
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
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersService, UsersService>();

            var connectionString =
                new MySqlConnectionStringBuilder(Environment.GetEnvironmentVariable("MUNDOB_DB_STR") ?? "");
            services.AddDbContext<MundoBalloonContext>(options =>
                options.UseMySql(connectionString.ToString(), new MySqlServerVersion(new Version(8, 0, 22))));
        }
    }
}