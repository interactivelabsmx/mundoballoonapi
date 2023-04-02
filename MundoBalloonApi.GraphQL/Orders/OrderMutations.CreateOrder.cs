using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Orders;

public partial class OrderMutations
{
    [Authorize]
    public async Task<business.DTOs.Entities.Orders> CreateOrder(string paymentId,
        [GlobalState("currentUser")] CurrentUser currentUser,
        [Service] IOrdersService ordersService,
        [Service] IProductService productsService,
        CancellationToken cancellationToken)
    {
        var order = await ordersService.AddOrder(currentUser.UserId, paymentId, cancellationToken);
        var items = await productsService.GetUserCartProducts(currentUser.UserId, cancellationToken);
        await ordersService.AddOrderProductDetailsRange(order, items, cancellationToken);
        await productsService.DeleteUserCartProducts(items.AsEnumerable(), cancellationToken);
        return order;
    }
}