using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public Task<bool> DeleteProductVariant(
        [Service] IProductService productService, int productVariantId) => productService.DeleteProductVariant(productVariantId);
}