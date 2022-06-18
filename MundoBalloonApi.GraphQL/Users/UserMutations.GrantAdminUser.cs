using System.Security.Claims;
using FirebaseAdmin.Auth;
using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public async Task<bool> GrantAdminUser(
        string userId,
        [Service] IUsersService usersService, CancellationToken cancellationToken)
    {
        var claims = new Dictionary<string, object> { { ClaimTypes.Role, "ADMIN" } };
        await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(userId, claims, cancellationToken);
        return true;
    }
}