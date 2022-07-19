using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.test.Fixtures;

namespace MundoBalloonApi.test.Infrastructure.Fixtures;

public class InMemoryDbContextFactory : IDbContextFactory<MundoBalloonContext>
{
    public MundoBalloonContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<MundoBalloonContext>()
            .UseInMemoryDatabase("MundoBalloonContextTest:Fixtures")
            .Options;

        var context = new MundoBalloonContext(options);
        var contextSeeder = new SeedDbContext(context);
        contextSeeder.Seed();
        return context;
    }
}