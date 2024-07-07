using AutoMapper;
using HotChocolate.Authorization;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [Authorize(Roles = new[] { "ADMIN" })]
    
    [UsePaging]
    public IQueryable<FirebaseUser> GetUsers(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        return mundoBalloonContext.Users.Select(u => GetFirebaseUser(u, mapper));
    }
}