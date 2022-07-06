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
    public async Task<ProductVariant?> GetProductVariantById([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productVariantId)
    {
        var productVariant = await mundoBalloonContext.ProductVariants
            .Include(pv => pv.ProductVariantMedia)
            .Include(pv => pv.ProductVariantValues)
            .ThenInclude(pvv => pvv.Variant)
            .Include(pv => pv.ProductVariantValues)
            .ThenInclude(pvv => pvv.VariantValue)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ProductVariantId == productVariantId);
        return mapper.Map<ProductVariant>(productVariant);
    }
}