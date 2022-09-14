using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using UserEvent = MundoBalloonApi.business.DTOs.Entities.UserEvent;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public async Task<UserEvent?> GetUserEventById([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int userEventid)
    {
        var userEvent = await mundoBalloonContext.UserEvents
        .Include(ue => ue.EventCartDetails)
        .Include(ue => ue.User)
        .AsNoTracking()
        .FirstOrDefaultAsync(ue => ue.UserEventId == userEventid);
        return mapper.Map<UserEvent>(userEvent);
    }
}