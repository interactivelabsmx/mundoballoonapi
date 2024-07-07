using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using Variant = MundoBalloonApi.business.DTOs.Entities.Variant;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionQueries
{
    [AllowAnonymous]
    
    public IQueryable<Variant> GetVariants(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<Variant>(mundoBalloonContext.Variants);
    }
}