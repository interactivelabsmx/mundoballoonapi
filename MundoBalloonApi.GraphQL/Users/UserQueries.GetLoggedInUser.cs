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
    public async Task<User?> GetLoggedInUser([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalStateAttribute("currentUser")] CurrentUser currentUser)
    {
        var user = await mundoBalloonContext.Users.FirstOrDefaultAsync(u => u.UserId == currentUser.UserId);
        return mapper.Map<User>(user);
    }
}