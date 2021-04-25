using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts
{
    public interface IUsersRepository
    {
        User Create(User user);
    }
}