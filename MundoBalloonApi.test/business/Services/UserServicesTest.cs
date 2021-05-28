using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Requests;
using MundoBalloonApi.business.Services;
using MundoBalloonApi.test.Fixtures;
using Xunit;

namespace MundoBalloonApi.test.business.Services
{
    [Collection("WithDatabase")]
    public class UsersServiceTests : IClassFixture<MapperFixture>
    {
        public UsersServiceTests(RepositoriesFixture fixture, MapperFixture mapperFixture)
        {
            Service = new UsersService(fixture.UsersRepository, mapperFixture.mapper);
        }

        private IUsersService Service { get; }

        [Fact]
        public void Test_GetUserOrCreateByAccountId_OK()
        {
            var user = Service.CreateOrGetUser(new CreateUserRequest
            {
                UserId = "123"
            });
            Assert.True(user.UserId != null);
        }
    }
}