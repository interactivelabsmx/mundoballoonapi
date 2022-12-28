using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartMutations
{
    [Authorize]
    public Task<OrderProductsDetails> AddOrderProductDetails(
        int orderId, int productVariantId, int amount, decimal price,
        [Service] IUsersService usersService,
        CancellationToken cancellationToken)
    {
        return usersService.AddOrderProductDetails(orderId, productVariantId, amount, price, cancellationToken);
    }
}