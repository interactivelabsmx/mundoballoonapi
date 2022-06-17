using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using User = MundoBalloonApi.business.DataObjects.Entities.User;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public async Task<User?> GetLoggedInUser([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalStateAttribute("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        var user = await mundoBalloonContext.Users.FirstOrDefaultAsync(u => u.UserId == currentUser.UserId,
            cancellationToken);
        return user == null ? null : mapper.Map<User>(user);
    }
}