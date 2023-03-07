using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductVariant = MundoBalloonApi.business.DTOs.Entities.ProductVariant;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<ProductVariant> GetProductsVariantsByUserId([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, string userId)
    {
        return mapper.ProjectTo<ProductVariant>(mundoBalloonContext.ProductVariants);
    }
}