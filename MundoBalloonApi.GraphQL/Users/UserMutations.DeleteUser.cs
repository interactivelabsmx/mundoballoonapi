using HotChocolate.AspNetCore.Authorization;
using FirebaseAdmin.Auth;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    public async Task<bool> DeleteUser(
        string userId,
        [Service] IUsersService usersService, CancellationToken cancellationToken)
    {
        await FirebaseAuth.DefaultInstance.DeleteUserAsync(userId, cancellationToken);
        return await usersService.DeleteUser(userId, cancellationToken);
    }
}