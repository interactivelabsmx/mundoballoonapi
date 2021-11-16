using AutoMapper;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using User = MundoBalloonApi.business.DataObjects.Entities.User;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public User? GetLoggedInUser([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalStateAttribute("currentUser")] CurrentUser currentUser)
    {
        var result = mundoBalloonContext.Users.Where(u => u.UserId == currentUser.UserId)
            .Include(u => u.UserProfile);
        var user = result.FirstOrDefault();
        return mapper.Map<User>(user);
    }
}