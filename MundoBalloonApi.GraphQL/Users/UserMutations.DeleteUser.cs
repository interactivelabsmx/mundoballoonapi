using FirebaseAdmin.Auth;
using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    [Authorize]
    public async Task<bool> DeleteUser(
        string userId,
        [Service] IUsersService usersService, CancellationToken cancellationToken)
    {
        // TODO: Add logic to only allow delete self or admin access
        await FirebaseAuth.DefaultInstance.DeleteUserAsync(userId, cancellationToken);
        return await usersService.DeleteUser(userId, cancellationToken);
    }
}