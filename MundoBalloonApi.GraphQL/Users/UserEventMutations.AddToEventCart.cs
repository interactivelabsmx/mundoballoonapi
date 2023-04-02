using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    [Authorize]
    public Task<EventCartDetail> AddToEventCart(
        int productVariantId, int userEventId, decimal quantity,
        [Service] IUsersService usersService,
        CancellationToken cancellationToken)
    {
        return usersService.AddToEventCart(productVariantId, userEventId, quantity, cancellationToken);
    }
}