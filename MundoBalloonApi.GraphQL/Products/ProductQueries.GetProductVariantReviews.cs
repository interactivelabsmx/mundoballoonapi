using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductVariantReview = MundoBalloonApi.business.DTOs.Entities.ProductVariantReview;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<ProductVariantReview> GetProductVariantReviews([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productId)
    {
        return mapper.ProjectTo<ProductVariantReview>(mundoBalloonContext.ProductVariantReviews.Where
        (p=> p.ProductVariant.ProductId == productId ).Include(p=>p.ProductVariant));
    }
}