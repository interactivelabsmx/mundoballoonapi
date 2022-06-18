using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize(Roles = new [] { "ADMIN" })]
    public Task<bool> DeleteProductVariant(
        [Service] IProductService productService, int productVariantId)
    {
        return productService.DeleteProductVariant(productVariantId);
    }
}