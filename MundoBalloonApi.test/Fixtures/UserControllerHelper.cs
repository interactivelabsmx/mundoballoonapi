using System.Net.Http;
using System.Threading.Tasks;
using MundoBalloonApi.business.DTOs.Requests;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.test.Fixtures
{
    public class UserControllerHelper
    {
        private readonly HttpClient _client;

        public UserControllerHelper(HttpClient client)
        {
            _client = client;
        }

        public async Task<User> CreateProfile()
        {
            var user = new CreateUserRequest
            {
                UserId = "123"
            };
            var httpResponse = await _client.PostAsJsonAsync("api/v1/admin/users", user);
            var resultUser = await httpResponse.Content.ReadAsAsync<User>();
            return resultUser;
        }
    }
}