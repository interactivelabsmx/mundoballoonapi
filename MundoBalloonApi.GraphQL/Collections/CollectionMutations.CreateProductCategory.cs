using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Collections;

[Authorize]
public partial class CollectionMutations
{
    public ProductCategory CreateProductCategory(ProductCategory input,
        [Service] ICollectionsService collectionsService)
    {
        return collectionsService.CreateProductCategory(input);
    }
}