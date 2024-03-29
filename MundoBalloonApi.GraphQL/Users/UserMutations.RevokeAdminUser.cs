using System.Security.Claims;
using FirebaseAdmin.Auth;
using HotChocolate.Authorization;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public async Task<bool> RevokeAdminUser(
        string userId, CancellationToken cancellationToken)
    {
        var claims = new Dictionary<string, object> { { ClaimTypes.Role, "" } };
        await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(userId, claims, cancellationToken);
        return true;
    }
}