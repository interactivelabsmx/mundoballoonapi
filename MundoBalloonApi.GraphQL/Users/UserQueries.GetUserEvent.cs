using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using AutoMapper;
namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserEvent> GetUserEvent([ScopedService] MundoBalloonContext mundoBalloonContext,
     [Service] IMapper mapper)
    {
        return mapper.ProjectTo<UserEvent>(mundoBalloonContext.UserEvents);
    }
}