using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<UserEvent> UpdateUserEvent(UserEvent input, [Service] IUsersService usersService,
    CancellationToken cancellationToken)
    {
        return usersService.UpdateUserEvent(input, cancellationToken);
    }
}