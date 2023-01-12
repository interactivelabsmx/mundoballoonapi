using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserOrderMutations
{
    [Authorize]
    public Task<bool> DeleteOrder(
        [Service] IUsersService usersService, int orderId, [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        return usersService.DeleteOrder(currentUser.UserId, orderId, cancellationToken);
    }
}