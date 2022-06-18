using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<VariantValue> CreateVariantValue(VariantValue input,
        [Service] ICollectionsService collectionsService)
    {
        return collectionsService.CreateVariantValue(input);
    }
}