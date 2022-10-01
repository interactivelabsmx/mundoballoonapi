using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using UserEvent = MundoBalloonApi.business.DTOs.Entities.UserEvent;
using MundoBalloonApi.business.DTOs.Entities;
namespace MundoBalloonApi.graphql.Users;

public partial class UserEventQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserEvent> GetUserEventByUserId([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser, CancellationToken cancellationToken)
    {
        return mapper.ProjectTo<UserEvent>(mundoBalloonContext.UserEvents.Where(u => u.UserId == currentUser.UserId));
    }
}