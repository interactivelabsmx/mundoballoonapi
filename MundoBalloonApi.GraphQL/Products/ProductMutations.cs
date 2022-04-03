using HotChocolate.AspNetCore.Authorization;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
[ExtendObjectType(Name = "Mutation")]
public partial class ProductMutations
{
}