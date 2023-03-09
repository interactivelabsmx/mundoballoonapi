using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<VariantsType> CreateVariantsType(string variantsType,
        [Service] ICollectionsService collectionsService, CancellationToken cancellationToken)
    {
        return collectionsService.CreateVariantsType(variantsType, cancellationToken);
    }
}