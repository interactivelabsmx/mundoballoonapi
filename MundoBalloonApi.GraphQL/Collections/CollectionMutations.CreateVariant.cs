using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Collections;

[Authorize]
public partial class CollectionMutations
{
    public Task<Variant> CreateVariant(Variant input,
        [Service] ICollectionsService collectionsService) => collectionsService.CreateVariant(input);
}