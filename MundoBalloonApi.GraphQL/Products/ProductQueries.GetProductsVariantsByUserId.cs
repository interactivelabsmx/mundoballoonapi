using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductVariant = MundoBalloonApi.business.DTOs.Entities.ProductVariant;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    
    public IQueryable<ProductVariant> GetProductsVariantsByUserId(
        [Service(ServiceKind.Pooled)] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, string userId)
    {
        return mapper.ProjectTo<ProductVariant>(mundoBalloonContext.ProductVariants);
    }
}