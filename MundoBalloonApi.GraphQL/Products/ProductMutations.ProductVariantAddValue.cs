using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public Task<ProductVariant> ProductVariantAddValue(
        ProductVariantValue input,
        [Service] IProductService productService)
    {
        return productService.ProductVariantAddValue(input);
    }
}