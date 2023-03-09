using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    [Authorize]
    public Task<UserEvent> UpdateUserEvent(UserEvent input, [Service] IUsersService usersService,
        CancellationToken cancellationToken)
    {
        return usersService.UpdateUserEvent(input, cancellationToken);
    }
}