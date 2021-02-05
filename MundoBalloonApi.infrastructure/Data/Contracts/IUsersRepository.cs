using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts
{
    public interface IUsersRepository
    {
        UserProfile Create(UserProfile userProfile);
        UserProfile Update(UserProfile userProfile);
    }
}