using AutoMapper;
using HotChocolate.Authorization;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using UserEvent = MundoBalloonApi.business.DTOs.Entities.UserEvent;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventQueries
{
    [Authorize]
    
    public IQueryable<UserEvent> GetUserEvents(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser)
    {
        return mapper.ProjectTo<UserEvent>(mundoBalloonContext.UserEvents.Where(u => u.UserId == currentUser.UserId));
    }
}