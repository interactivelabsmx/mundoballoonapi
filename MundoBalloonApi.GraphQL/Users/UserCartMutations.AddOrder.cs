using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartMutations
{
    [Authorize]
    public Task<Orders> AddOrder(
        [GlobalState("currentUser")] CurrentUser currentUser, int userAddressesId, int userProfileId,
        [Service] IUsersService usersService,
        CancellationToken cancellationToken)
    {
        return usersService.AddOrder(currentUser.UserId, userAddressesId, userProfileId, cancellationToken);
    }
}