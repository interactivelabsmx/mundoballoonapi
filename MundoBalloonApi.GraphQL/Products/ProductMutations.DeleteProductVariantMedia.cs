using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public Task<bool> DeleteProductVariantMedia(
        [Service] IProductService productService, int productVariantMediaId) => productService.DeleteProductVariantMedia(productVariantMediaId);
}