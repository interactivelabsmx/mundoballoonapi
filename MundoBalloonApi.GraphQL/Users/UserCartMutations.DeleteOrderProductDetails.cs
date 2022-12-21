using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartMutations
{
    [Authorize]
    public Task<bool> DeleteOrderProductDetails(
        [Service] IUsersService usersService, int orderDetailsProductId, [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        return usersService.DeleteOrderProductDetails(currentUser.UserId, orderDetailsProductId, cancellationToken);
    }
}