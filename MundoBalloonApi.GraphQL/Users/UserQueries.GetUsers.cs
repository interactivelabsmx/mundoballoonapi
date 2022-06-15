using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    [UsePaging]
    public IQueryable<FirebaseUser> GetUsers([ScopedService] MundoBalloonContext mundoBalloonContext)
    {
        return mundoBalloonContext.Users.Select(u => GetFirebaseUser(u));
    }
}