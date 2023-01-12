using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    [Authorize]
    public Task<bool> DeleteUserProfile(
        [Service] IUsersService usersService, int userProfileId, [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        return usersService.DeleteUserProfile(currentUser.UserId, userProfileId, cancellationToken);
    }
}