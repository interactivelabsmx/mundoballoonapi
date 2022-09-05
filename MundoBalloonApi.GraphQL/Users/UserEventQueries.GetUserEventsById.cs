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
            .Include(ue => ue.UserEventId)
            .Include(ue => ue.UserId)
            .Include(ue => ue.EventName)
            .Include(ue => ue.EventDate)
            .Include(ue => ue.EventDetails)
            .Include(ue => ue.CreatedAt)
            .Include(ue => ue.UpdatedAt)
            .Include(ue => ue.IsDeleted)
            .IgnoreAutoIncludes()
            .AsNoTracking()
           .FirstOrDefaultAsync(ue => ue.UserEventId == userEventid);
        return mapper.Map<UserEvent>(userEvent);
    }
}