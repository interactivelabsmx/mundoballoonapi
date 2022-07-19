using Bogus;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.infrastructure.Data.Repositories;
using MundoBalloonApi.test.Infrastructure.Fixtures;
using Xunit;

namespace MundoBalloonApi.test.infrastructure.Data;

public class UserRepositoryTest : SharedDatabaseFixture
{
    [Fact]
    public async Task Test_Create_OK()
    {
        var random = new Randomizer();
        var cancellationToken = new CancellationTokenSource().Token;
        var userRepository = new UsersRepository(Factory);
        var user = await userRepository.Create(new User
        {
            UserId = random.Replace("#########")
        }, cancellationToken);
        Assert.True(user.UserId != null);
    }

    [Fact]
    public async Task Test_GetById_OK()
    {
        var cancellationToken = new CancellationTokenSource().Token;
        var userRepository = new UsersRepository(Factory);
        var user = await userRepository.GetById("1", cancellationToken);
        Assert.True(user != null);
    }

    [Fact]
    public async Task Test_Delete_OK()
    {
        var cancellationToken = new CancellationTokenSource().Token;
        var userRepository = new UsersRepository(Factory);
        var user = await userRepository.DeleteUser("1", cancellationToken);
        Assert.True(user);
    }
}