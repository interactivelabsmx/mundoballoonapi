using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using UserAddresses = MundoBalloonApi.business.DTOs.Entities.UserAddresses;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserAddresses> GetUserAddresses([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, string userId)
    {
        return mapper.ProjectTo<UserAddresses>(mundoBalloonContext.UserAddresses.Where(uc => uc.UserId == userId));
    }
    
}