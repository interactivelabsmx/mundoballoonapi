using AutoMapper;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    [UsePaging]
    public async Task<FirebaseUser?> GetUserById(string userId, [ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        var user = await mundoBalloonContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        return user == null ? null : GetFirebaseUser(user, mapper);
    }
}