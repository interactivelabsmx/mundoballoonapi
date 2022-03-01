using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.business.DataObjects.Requests.Collections;

namespace MundoBalloonApi.graphql.Collections;

[Authorize]
public partial class CollectionMutations
{
    public ProductCategory CreateProductCategory(CreateProductCategoryRequest input, [Service] ICollectionsService collectionsService)
    {
        return collectionsService.CreateProductCategory(input);
    }
}