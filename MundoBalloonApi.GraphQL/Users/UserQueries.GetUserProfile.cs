using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using UserProfile = MundoBalloonApi.business.DTOs.Entities.UserProfile;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserProfile> GetUserProfile([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, string userId)
    {
        return mapper.ProjectTo<UserProfile>(mundoBalloonContext.UserProfiles.Where(uc => uc.UserId == userId));
    }
}