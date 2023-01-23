using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize]
    public Task<ProductVariantReview> UpdateProductVariantReview(int productVariantId,int productVariantReviewId,
        [GlobalState("currentUser")] CurrentUser currentUser,
        int rating, string comments,
        [Service] IUsersService usersService,
        CancellationToken cancellationToken)
    {
        return usersService.UpdateProductVariantReview(productVariantId,productVariantReviewId, currentUser.UserId,rating, comments,
            cancellationToken);
    }
}