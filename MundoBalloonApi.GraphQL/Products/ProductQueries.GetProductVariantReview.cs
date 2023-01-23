using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductVariantReview = MundoBalloonApi.business.DTOs.Entities.ProductVariantReview;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<ProductVariantReview> GetProductVariantReviews([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productVariantId)
    {
        return mapper.ProjectTo<ProductVariantReview>(mundoBalloonContext.ProductVariantReviews.Where(p=> p.ProductVariantId == productVariantId));
    }
}