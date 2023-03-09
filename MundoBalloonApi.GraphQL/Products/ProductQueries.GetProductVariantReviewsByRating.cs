using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductVariantReview = MundoBalloonApi.business.DTOs.Entities.ProductVariantReview;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<ProductVariantReview> GetProductVariantReviewsByRating([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int rating)
    {
        return mapper.ProjectTo<ProductVariantReview>(mundoBalloonContext.ProductVariantReviews.Where(p=> p.Rating == rating));
    }
}