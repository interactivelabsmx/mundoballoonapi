using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using UserEvent = MundoBalloonApi.business.DTOs.Entities.UserEvent;
using MundoBalloonApi.business.DTOs.Entities;
namespace MundoBalloonApi.graphql.Users;

public partial class UserEventQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserEvent> GetUserEventByUserId([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, string userId, CancellationToken cancellationToken)
    {
        return mapper.ProjectTo<UserEvent>(mundoBalloonContext.UserEvents.Where(u => u.UserId == userId));
    }
}