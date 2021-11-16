using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.test.Fixtures;

public class RepositoriesFixture : IDisposable
{
    public RepositoriesFixture()
    {
        const string connectionString = "Server=localhost;Database=mundoBalloon_test;User=root;Password=#Labs2013;";
        var builder = new DbContextOptionsBuilder<MundoBalloonContext>();
        builder.UseMySql(connectionString, new MySqlServerVersion("8.0.22"));
        var options = builder.Options;
        MundoBalloonContext = new MundoBalloonContext(options);
    }

    public IUsersRepository UsersRepository { get; }
    private MundoBalloonContext MundoBalloonContext { get; }

    public void Dispose()
    {
        MundoBalloonContext.Dispose();
    }
}