using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
public partial class ProductMutations
{
    public bool? DeleteProduct(
        [Service] IProductService productService, int productId)
    {
        return productService.DeleteProduct(productId);
    }
}