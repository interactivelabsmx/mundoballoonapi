using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using UserProfile = MundoBalloonApi.business.DTOs.Entities.UserProfile;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserProfile> GetUserProfile(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser)
    {
        return mapper.ProjectTo<UserProfile>(
            mundoBalloonContext.UserProfiles.Where(uc => uc.UserId == currentUser.UserId));
    }
}