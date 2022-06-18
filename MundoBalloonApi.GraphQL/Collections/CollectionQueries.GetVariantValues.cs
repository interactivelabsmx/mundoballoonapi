using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using VariantValue = MundoBalloonApi.business.DataObjects.Entities.VariantValue;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<VariantValue> GetVariantValues([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int variantId)
    {
        var variantValues = mundoBalloonContext.VariantValues.Where(vv => vv.VariantId == variantId);
        return mapper.ProjectTo<VariantValue>(variantValues);
    }
}