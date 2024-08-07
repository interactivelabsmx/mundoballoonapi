using AutoMapper;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public async Task<FirebaseUser?> GetUserById(string userId, MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper,
        CancellationToken cancellationToken)
    {
        var user = await mundoBalloonContext.Users.FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);
        return user == null ? null : GetFirebaseUser(user, mapper);
    }
}