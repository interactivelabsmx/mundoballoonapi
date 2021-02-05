using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.test.Fixtures;
using Xunit;

namespace MundoBalloonApi.test.infrastructure.Data
{
    [Collection("WithDatabase")]
    public class UserRepositoryTest
    {
        private readonly RepositoriesFixture _fixture;

        public UserRepositoryTest(RepositoriesFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Test_CreateOrGet_OK()
        {
            var userProfile = _fixture.UsersRepository.Create(new UserProfile
            {
                Picture = "https://picture",
                ProcessorId = "1234"
            });
            Assert.True(userProfile.UserId != null);
        }
    }
}