using AutoMapper;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using User = MundoBalloonApi.business.DTOs.Entities.User;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [Authorize]
    public async Task<User?> GetLoggedInUser(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        var user = await mundoBalloonContext.Users.FirstOrDefaultAsync(u => u.UserId == currentUser.UserId,
            cancellationToken);
        return user == null ? null : mapper.Map<User>(user);
    }
}