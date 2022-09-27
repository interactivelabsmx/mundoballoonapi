using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface IUsersService
{
    Task<User> CreateOrGetUser(string userId, CancellationToken cancellationToken);
    Task<bool> DeleteUser(string userId, CancellationToken cancellationToken);
    Task<UserEvent>CreateUserEvent(string UserId, string Name, string details, CancellationToken cancellationToken);
    Task<bool> DeleteUserEvent(string userId,int userEventId, CancellationToken cancellationToken);
    Task<UserEvent> UpdateUserEvent(UserEvent userEvent, CancellationToken cancellationToken);
}