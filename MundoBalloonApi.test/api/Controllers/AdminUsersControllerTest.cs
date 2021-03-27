using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using MundoBalloonApi.test.Fixtures;
using MundoBalloonApi.web;
using Xunit;

namespace MundoBalloonApi.test.api.Controllers
{
    public class AdminUsersControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>, IDisposable
    {
        private readonly HttpClient _client;
        private readonly UserControllerHelper _helper;

        public AdminUsersControllerTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _helper = new UserControllerHelper(_client);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        [Fact]
        public async void Test_GetUserOrCreateByAccountId_OK()
        {
            var user = await _helper.CreateProfile();
            Assert.NotNull(user);
        }
    }
}