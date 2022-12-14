using AutoMapper;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using UserAddresses = MundoBalloonApi.business.DTOs.Entities.UserAddresses;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserAddresses> GetUserAddresses([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, string userId)
    {
        return mapper.ProjectTo<UserAddresses>(mundoBalloonContext.UserAddresses.Where(uc => uc.UserId == userId));
    }
    
}