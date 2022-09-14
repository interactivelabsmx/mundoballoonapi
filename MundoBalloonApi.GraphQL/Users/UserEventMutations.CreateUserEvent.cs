using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    public Task<UserEvent> CreateUserEvent(
        int userId,
        [Service] IUsersService usersService,CancellationToken cancellationToken)
    {
        return usersService.CreateOrGetUserEvent(userId,cancellationToken);
    }
}