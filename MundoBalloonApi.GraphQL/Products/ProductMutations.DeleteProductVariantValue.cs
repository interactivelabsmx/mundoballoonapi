using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize(Roles = new [] { "ADMIN" })]
    public Task<bool> DeleteProductVariantValue(
        [Service] IProductService productService, int productVariantId, int variantId, int variantValueId)
    {
        return productService.DeleteProductVariantValue(productVariantId, variantId, variantValueId);
    }
}