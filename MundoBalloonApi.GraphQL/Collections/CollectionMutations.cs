using HotChocolate.AspNetCore.Authorization;
namespace MundoBalloonApi.graphql.Collections;

[Authorize(Roles = new [] { "ADMIN" })]
[ExtendObjectType(Name = "Mutation")]
public partial class CollectionMutations
{
}