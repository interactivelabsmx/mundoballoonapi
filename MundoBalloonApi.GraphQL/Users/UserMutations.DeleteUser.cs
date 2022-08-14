using FirebaseAdmin.Auth;
using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public async Task<bool> DeleteUser(
        string userId,
        [Service] IUsersService usersService, CancellationToken cancellationToken)
    {
        await FirebaseAuth.DefaultInstance.DeleteUserAsync(userId, cancellationToken);
        return await usersService.DeleteUser(userId, cancellationToken);
    }
}