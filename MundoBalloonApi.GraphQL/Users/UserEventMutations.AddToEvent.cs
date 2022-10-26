using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    [Authorize]
    public Task<EventCartDetail> AddToEvent(
        int productVariantId, int userEventId, double quantity,
        [Service] IUsersService usersService,
        CancellationToken cancellationToken)
    {
        return usersService.AddToEvent(productVariantId, userEventId,quantity, cancellationToken);
    }
}