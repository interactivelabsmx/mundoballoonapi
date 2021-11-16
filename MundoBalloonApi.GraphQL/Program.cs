using Microsoft.AspNetCore;

namespace MundoBalloonApi.graphql;

public class Program
{
    public static Task Main(string[] args)
    {
        return CreateWebHostBuilder(args).Build().RunAsync();
    }

    private static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        return WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}