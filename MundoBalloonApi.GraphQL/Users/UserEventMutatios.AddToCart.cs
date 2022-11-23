using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    [Authorize]
    public Task<UserCart> AddToCart(
        string userId, string sku, decimal quantity, decimal price, int productVariantId,
        [Service] IUsersService usersService,
        CancellationToken cancellationToken)
    {
        return usersService.AddToCart(userId, sku, quantity, price,productVariantId, cancellationToken);
    }
}