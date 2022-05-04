using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductVariant = MundoBalloonApi.business.DataObjects.Entities.ProductVariant;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [UseDbContext(typeof(MundoBalloonContext))]
    public ProductVariant? GetProductVariantById([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productVariantId)
    {
        var productVariant = mundoBalloonContext.ProductVariants
            .Include(pv => pv.ProductVariantMedia)
            .Include(pv => pv.ProductVariantValues)
            .ThenInclude(pvv => pvv.Variant)
            .Include(pv => pv.ProductVariantValues)
            .ThenInclude(pvv => pvv.VariantValue)
            .AsNoTracking()
            .FirstOrDefault(p => p.ProductVariantId == productVariantId);
        return productVariant != null ? mapper.Map<ProductVariant>(productVariant) : null;
    }
}