using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize]
    public async Task<ProductVariantReview> AddProductVariantReview(
        int productVariantId, [GlobalState("currentUser")] CurrentUser currentUser, int rating, string comments,
        [Service] IProductService productService,
        CancellationToken cancellationToken)
    {
        return await productService.AddProductVariantReview(productVariantId, currentUser.UserId, rating, comments,
            cancellationToken);
    }
}