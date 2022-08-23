using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using Product = MundoBalloonApi.business.DTOs.Entities.Product;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public async Task<Product?> GetProductById([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productId)
    {
        var product = await mundoBalloonContext.Products
            .Include(p => p.ProductCategory)
            .Include(p => p.ProductVariants)
            .ThenInclude(pv => pv.ProductVariantMedia)
            .Include(p => p.ProductVariants)
            .ThenInclude(pv => pv.ProductVariantValues)
            .ThenInclude(pv => pv.Variant)
            .Include(p => p.ProductVariants)
            .ThenInclude(pv => pv.ProductVariantValues)
            .ThenInclude(pv => pv.VariantValue)
            .IgnoreAutoIncludes()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ProductId == productId);
        return mapper.Map<Product>(product);
    }
}