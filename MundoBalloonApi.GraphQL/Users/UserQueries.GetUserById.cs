using HotChocolate.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public async Task<FirebaseUser?> GetUserById(string userId, [ScopedService] MundoBalloonContext mundoBalloonContext,
        CancellationToken cancellationToken)
    {
        var user = await mundoBalloonContext.Users.FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);
        return user == null ? null : GetFirebaseUser(user);
    }
}