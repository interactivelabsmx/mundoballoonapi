using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public ProductVariant ProductVariantAddValue(
        ProductVariantValue input,
        [Service] IProductService productService)
    {
        var productVariant = productService.ProductVariantAddValue(input);
        return productVariant;
    }
}