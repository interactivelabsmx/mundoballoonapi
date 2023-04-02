using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize]
    public Task<bool> DeleteProductVariantReview(
        int productVariantReviewId,
        [GlobalState("currentUser")] CurrentUser currentUser,
        [Service] IProductService productService,
        CancellationToken cancellationToken)
    {
        return productService.DeleteProductVariantReview(productVariantReviewId, currentUser.UserId, cancellationToken);
    }
}