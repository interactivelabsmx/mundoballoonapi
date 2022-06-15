using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public Task<ProductVariant> CreateProductVariant(
        ProductVariant input,
        [Service] IProductService productService)
    {
        return productService.CreateProductVariant(input);
    }
}