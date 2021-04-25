using MundoBalloonApi.business.DTOs.Requests;
using User = MundoBalloonApi.business.DTOs.Models.User;

namespace MundoBalloonApi.business.Contracts
{
    public interface IUsersService
    {
        User Create(CreateUserRequest createUserRequest);
    }
}