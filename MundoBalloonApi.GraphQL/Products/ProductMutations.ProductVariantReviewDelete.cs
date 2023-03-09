using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize]
    public Task<bool> DeleteProductVariantReview(
        [Service] IUsersService usersService, int productVariantReviewId,
        [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        return usersService.DeleteProductVariantReview(productVariantReviewId, currentUser.UserId, cancellationToken);
    }
}