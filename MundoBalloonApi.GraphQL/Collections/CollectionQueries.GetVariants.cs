using AutoMapper;
using MundoBalloonApi.infrastructure.Data.Models;
using Variant = MundoBalloonApi.business.DataObjects.Entities.Variant;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionQueries
{
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<Variant> GetVariants([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<Variant>(mundoBalloonContext.Variants);
    }
}