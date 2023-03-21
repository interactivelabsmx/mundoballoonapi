using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductVariantReview = MundoBalloonApi.business.DTOs.Entities.ProductVariantReview;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<ProductVariantReview> GetProductVariantReviewsByUser(
        [Service(ServiceKind.Pooled)] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser)
    {
        return mapper.ProjectTo<ProductVariantReview>(
            mundoBalloonContext.ProductVariantReviews.Where(p => p.UserId == currentUser.UserId));
    }
}