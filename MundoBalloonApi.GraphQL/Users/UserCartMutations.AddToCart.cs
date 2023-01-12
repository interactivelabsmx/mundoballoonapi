using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartMutations
{
    [Authorize]
    public Task<UserCart> AddToCart(string sku, double quantity, double price, int productVariantId,
        [Service] IUsersService usersService, [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        return usersService.AddToCart(currentUser.UserId, sku, quantity, price, productVariantId, cancellationToken);
    }
}