using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using UserAddresses = MundoBalloonApi.business.DTOs.Entities.UserAddresses;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserAddresses> GetUserAddresses(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser)
    {
        return mapper.ProjectTo<UserAddresses>(
            mundoBalloonContext.UserAddresses.Where(uc => uc.UserId == currentUser.UserId));
    }
}