using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;
namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    [Authorize]
    public Task<bool> DeleteUserEvent(
        [Service] IUsersService usersService, int userEventId,
        CancellationToken cancellationToken, [GlobalState("currentUser")] CurrentUser currentUser)
    {
        return usersService.DeleteUserEvent(currentUser.UserId,userEventId,cancellationToken);
    }
}