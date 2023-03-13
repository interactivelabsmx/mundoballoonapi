using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using UserEvent = MundoBalloonApi.business.DTOs.Entities.UserEvent;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public async Task<UserEvent?> GetUserEventById(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int userEventId)
    {
        var userEvent = await mundoBalloonContext.UserEvents
            .Include(ue => ue.EventCartDetails)
            .Include(ue => ue.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(ue => ue.UserEventId == userEventId);
        return mapper.Map<UserEvent>(userEvent);
    }
}