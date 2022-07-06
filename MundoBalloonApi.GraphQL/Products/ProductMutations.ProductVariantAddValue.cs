using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<ProductVariant> ProductVariantAddValue(
        ProductVariantValue input,
        [Service] IProductService productService)
    {
        return productService.ProductVariantAddValue(input);
    }
}