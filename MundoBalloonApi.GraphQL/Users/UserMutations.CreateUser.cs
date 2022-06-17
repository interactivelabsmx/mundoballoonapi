using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    public Task<User> CreateUser(
        string userId,
        [Service] IUsersService usersService, CancellationToken cancellationToken)
    {
        return usersService.CreateOrGetUser(userId, cancellationToken);
    }
}