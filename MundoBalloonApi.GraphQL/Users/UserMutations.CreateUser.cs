using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    public async Task<User> CreateUser(
        string userId,
        [Service] IUsersService usersService)
    {
        return await usersService.CreateOrGetUser(userId);
    }
}