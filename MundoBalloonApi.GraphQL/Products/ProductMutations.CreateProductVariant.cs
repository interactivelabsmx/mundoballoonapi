using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public ProductVariant CreateProductVariant(
        ProductVariant input,
        [Service] IProductService productService)
    {
        var productVariant = productService.CreateProductVariant(input);
        return productVariant;
    }
}