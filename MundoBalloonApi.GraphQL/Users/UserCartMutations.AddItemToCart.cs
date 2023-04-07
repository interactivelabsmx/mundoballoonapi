using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartMutations
{
    [Authorize]
    public Task<UserCartProduct?> AddItemToCart(string sku,
        [Service] IUsersService usersService, [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        return usersService.AddItemToCart(currentUser.UserId, sku, cancellationToken);
    }
}