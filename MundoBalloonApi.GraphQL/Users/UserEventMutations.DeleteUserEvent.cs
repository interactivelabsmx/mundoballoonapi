using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    [Authorize]
    public Task<bool> DeleteUserEvent(
        [Service] IUsersService usersService, int userEventId, [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        return usersService.DeleteUserEvent(currentUser.UserId, userEventId, cancellationToken);
    }
}