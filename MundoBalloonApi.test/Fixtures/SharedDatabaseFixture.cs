using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.test.Fixtures;

public abstract class SharedDatabaseFixture : IDisposable
{
    private IDbContextFactory<MundoBalloonContext>? _factory;

    protected SharedDatabaseFixture()
    {
        _factory = new InMemoryDbContextFactory();
    }

    protected IDbContextFactory<MundoBalloonContext> Factory => _factory ?? new InMemoryDbContextFactory();

    public void Dispose()
    {
        _factory = null;
    }
}