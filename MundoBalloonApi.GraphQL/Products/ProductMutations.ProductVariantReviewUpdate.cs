using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize]
    public Task<ProductVariantReview> UpdateProductVariantReview(int productVariantId, int productVariantReviewId,
        int rating, string comments,
        [GlobalState("currentUser")] CurrentUser currentUser,
        [Service] IProductService productService,
        CancellationToken cancellationToken)
    {
        return productService.UpdateProductVariantReview(productVariantId, productVariantReviewId, currentUser.UserId,
            rating, comments,
            cancellationToken);
    }
}