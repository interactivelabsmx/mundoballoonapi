using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
public partial class ProductMutations
{
    public Boolean? DeleteProduct(
        [Service] IProductService productService, int productId)
    {
        return productService.DeleteProduct(productId);
    }
}