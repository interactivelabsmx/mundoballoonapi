using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public bool? DeleteProductVariantMedia(
        [Service] IProductService productService, int productVariantMediaId)
    {
        return productService.DeleteProductVariantMedia(productVariantMediaId);
    }
}