using MundoBalloonApi.infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MundoBalloonApi.test.Fixtures
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                const string connectionString = "Server=localhost;Database=mundob-test;User=root;Password=#Labs2013;";
                services.AddDbContext<MundoBalloonContext>(options => options.UseMySql(connectionString, new MySqlServerVersion("8.0.22")));
            });
        }
    }
}
