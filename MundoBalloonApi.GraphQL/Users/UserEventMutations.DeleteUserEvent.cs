using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;
namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<bool> DeleteUserEvent(
        [Service] IUsersService usersService, int userEventId,
        CancellationToken cancellationToken, [GlobalState("currentUser")] CurrentUser currentUser,
        string userId)
    {
        return usersService.DeleteUserEvent(userId,userEventId,cancellationToken);
    }
}