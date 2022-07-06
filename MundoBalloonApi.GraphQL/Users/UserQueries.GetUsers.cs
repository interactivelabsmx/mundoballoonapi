using AutoMapper;
using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [Authorize(Roles = new[] { "ADMIN" })]
    [UseDbContext(typeof(MundoBalloonContext))]
    [UsePaging]
    public IQueryable<FirebaseUser> GetUsers([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        return mundoBalloonContext.Users.Select(u => GetFirebaseUser(u, mapper));
    }
}