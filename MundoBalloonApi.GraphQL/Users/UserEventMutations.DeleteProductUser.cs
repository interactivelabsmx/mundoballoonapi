using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    [AllowAnonymous]
    public Task<bool> DeleteProductUser(
        [Service] IUsersService usersService, string sku,  [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        return usersService.DeleteProductUser(currentUser.UserId, sku, cancellationToken);
    }
}