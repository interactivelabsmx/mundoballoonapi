using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    public Task<UserEvent> CreateUserEvent(
        string name, string details,
        [Service] IUsersService usersService,
        CancellationToken cancellationToken, [GlobalState("currentUser")] CurrentUser currentUser)
    {
        return usersService.CreateUserEvent(currentUser.UserId, name, details, cancellationToken);
    }
}