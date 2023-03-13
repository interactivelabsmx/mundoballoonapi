using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    [Authorize]
    public Task<UserEvent> CreateUserEvent(
        string name, string details, DateTime date,
        [Service] IUsersService usersService, [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        return usersService.CreateUserEvent(currentUser.UserId, name, details, date, cancellationToken);
    }
}