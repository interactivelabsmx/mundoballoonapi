using HotChocolate.AspNetCore.Authorization;
using System.Security.Claims;
using FirebaseAdmin.Auth;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    public async Task<bool> GrantAdminUser(
        string userId,
        [Service] IUsersService usersService, CancellationToken cancellationToken)
    {
        var claims = new Dictionary<string, object> { { ClaimTypes.Role, "ADMIN" } };
        await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(userId, claims, cancellationToken);
        return true;
    }
}