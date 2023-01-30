using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using Variant = MundoBalloonApi.business.DTOs.Entities.Variant;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<Variant> GetVariants([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<Variant>(mundoBalloonContext.Variants);
    }
}