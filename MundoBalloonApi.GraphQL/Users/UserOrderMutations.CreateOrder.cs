using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.graphql.Users.Requests;

namespace MundoBalloonApi.graphql.Users;

public partial class UserOrderMutations
{
    [Authorize]
    public async Task<Orders> CreateOrder(CreateOrderRequests input,
        [GlobalState("currentUser")] CurrentUser currentUser,
        [Service] IUsersService usersService,
        CancellationToken cancellationToken)
    {
        if (input.Order == null || input.OrderItems == null) return new Orders();
        var order = await usersService.AddOrder(currentUser.UserId, input.Order.UserAddressesId,
            input.Order.UserProfileId, cancellationToken);
        await usersService.AddOrderProductDetailsRange(order, input.OrderItems, cancellationToken);
        return order;
    }
}