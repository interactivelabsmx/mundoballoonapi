using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface IUsersRepository
{
    User? GetById(string userId);

    Task<User> Create(User user, CancellationToken cancellationToken);

    Task<bool> DeleteUser(string userId, CancellationToken cancellationToken);
}