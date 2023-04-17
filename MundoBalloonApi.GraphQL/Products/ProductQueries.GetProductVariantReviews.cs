using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductVariantReview = MundoBalloonApi.business.DTOs.Entities.ProductVariantReview;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<ProductVariantReview> GetProductVariantReviews(
        [Service(ServiceKind.Pooled)] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productId)
    {
        return mapper.ProjectTo<ProductVariantReview>(mundoBalloonContext.ProductVariantReviews
            .Where(p => p.ProductVariant != null && p.ProductVariant.ProductId == productId)
            .Include(p => p.ProductVariant));
    }
}