using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<ProductCategory> CreateProductCategory(ProductCategory input,
        [Service] ICollectionsService collectionsService, CancellationToken cancellationToken)
    {
        return collectionsService.CreateProductCategory(input, cancellationToken);
    }
}