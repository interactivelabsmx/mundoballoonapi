using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize(Roles = new [] { "ADMIN" })]
    public Task<ProductVariant> UpdateProductVariant(ProductVariantEntity input,
        [Service] IProductService productService)
    {
        return productService.UpdateProductVariant(input);
    }
}