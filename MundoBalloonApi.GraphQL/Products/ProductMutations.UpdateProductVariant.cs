using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public Task<ProductVariant> UpdateProductVariant(ProductVariantEntity input,
        [Service] IProductService productService)
    {
        return productService.UpdateProductVariant(input);
    }
}