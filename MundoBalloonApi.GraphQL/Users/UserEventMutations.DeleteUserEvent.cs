using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<bool> DeleteUserEvent(
        [Service] IUsersService usersService, int userEventId)
    {
        return usersService.DeleteUserEvent(userEventId);
    }
}