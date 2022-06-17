using HotChocolate.AspNetCore.Authorization;

namespace MundoBalloonApi.graphql.Products;

[Authorize(Roles = new [] { "ADMIN" })]
[ExtendObjectType(Name = "Mutation")]
public partial class ProductMutations
{
}