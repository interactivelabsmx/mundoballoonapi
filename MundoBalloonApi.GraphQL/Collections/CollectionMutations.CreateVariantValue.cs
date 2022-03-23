using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Collections;

[Authorize]
public partial class CollectionMutations
{
    public VariantValue CreateVariantValue(VariantValue input,
        [Service] ICollectionsService collectionsService)
    {
        return collectionsService.CreateVariantValue(input);
    }
}