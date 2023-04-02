using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Orders;

public partial class OrderMutations
{
    [Authorize]
    public Task<bool> DeleteOrder(
        int orderId, [GlobalState("currentUser")] CurrentUser currentUser,
        [Service] IOrdersService ordersService,
        CancellationToken cancellationToken)
    {
        return ordersService.DeleteOrder(currentUser.UserId, orderId, cancellationToken);
    }
}