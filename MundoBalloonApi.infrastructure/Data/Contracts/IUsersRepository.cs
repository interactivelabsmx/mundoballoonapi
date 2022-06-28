using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface IUsersRepository
{
    Task<User?> GetById(string userId, CancellationToken cancellationToken);

    Task<User> Create(User user, CancellationToken cancellationToken);

    Task<bool> DeleteUser(string userId, CancellationToken cancellationToken);
}