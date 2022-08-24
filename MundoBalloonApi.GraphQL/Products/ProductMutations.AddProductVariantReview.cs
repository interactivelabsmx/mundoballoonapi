using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize]
    public async Task<ProductVariant?> AddProductVariantReview(
        ProductVariantReview input,
        [Service] IProductService productService,
        CancellationToken cancellationToken = default)
    {
        return await productService.AddProductVariantReview(input);
    }
}