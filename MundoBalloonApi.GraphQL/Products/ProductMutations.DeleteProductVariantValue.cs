using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public Task<bool> DeleteProductVariantValue(
        [Service] IProductService productService, int productVariantId, int variantId, int variantValueId)
    {
        return productService.DeleteProductVariantValue(productVariantId, variantId, variantValueId);
    }
}