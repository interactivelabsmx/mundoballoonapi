using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<bool> DeleteProduct(
        [Service] IProductService productService, int productId)
    {
        return productService.DeleteProduct(productId);
    }
}