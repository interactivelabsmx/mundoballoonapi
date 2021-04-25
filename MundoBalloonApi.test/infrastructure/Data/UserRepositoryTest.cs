using System;
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
            var user = _fixture.UsersRepository.Create(new User
            {
                Name = "test",
                Email = "test.user@mail.com",
                EmailVerified = DateTime.Now,
            });
            Assert.True(user.Email != null);
        }
    }
}