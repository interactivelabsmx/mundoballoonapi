using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<UserEvent>CreateUserEvent(UserEvent input,
        [Service] IUsersService usersService)
    {
        return usersService.CreateUserEvent(input);
    }
}