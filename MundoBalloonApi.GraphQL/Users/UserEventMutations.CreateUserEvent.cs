using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    public Task<UserEvent> CreateUserEvent(
        string userId, string name, string details,
        [Service] IUsersService usersService,
        CancellationToken cancellationToken)
    {
        return usersService.CreateUserEvent(userId, name, details, cancellationToken);
    }
}