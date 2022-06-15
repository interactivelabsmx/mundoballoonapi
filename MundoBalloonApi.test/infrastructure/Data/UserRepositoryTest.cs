using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.test.Fixtures;
using Xunit;

namespace MundoBalloonApi.test.infrastructure.Data;

[Collection("WithDatabase")]
public class UserRepositoryTest
{
    private readonly RepositoriesFixture _fixture;

    public UserRepositoryTest(RepositoriesFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Test_CreateOrGet_OK()
    {
        var cancellationToken = new CancellationTokenSource().Token;
        var user = await _fixture.UsersRepository.Create(new User
        {
            UserId = "123"
        }, cancellationToken);
        Assert.True(user.UserId != null);
    }
}