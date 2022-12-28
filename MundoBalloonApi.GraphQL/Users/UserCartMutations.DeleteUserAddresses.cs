using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartMutations
{
    [Authorize]
    public Task<bool> DeleteUserAddresses(
        [Service] IUsersService usersService, int userAddressesId,  [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        return usersService.DeleteUserAddresses(currentUser.UserId, userAddressesId, cancellationToken);
    }
}