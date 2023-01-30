using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using VariantsType = MundoBalloonApi.business.DTOs.Entities.VariantsType;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<VariantsType> GetVariantsType([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<VariantsType>(mundoBalloonContext.VariantsTypes);
    }
}