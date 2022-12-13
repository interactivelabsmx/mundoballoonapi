using AutoMapper;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using UserProfile = MundoBalloonApi.infrastructure.Data.Models.UserProfile;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserProfile> GetUserProfiles([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper,  string userId)
    {
        return mapper.ProjectTo<UserProfile>(mundoBalloonContext.UserProfile.Where(u => u.UserId == userId));
    }
}