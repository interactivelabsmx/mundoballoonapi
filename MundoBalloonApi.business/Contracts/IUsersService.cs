using MundoBalloonApi.business.Dtos;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.business.Contracts
{
    public interface IUsersService
    {
        UserProfile Create(CreateUserProfileRequest userProfileRequest);
        UserProfile Update(UpdateUserProfileRequest userProfileRequest);
    }
}
