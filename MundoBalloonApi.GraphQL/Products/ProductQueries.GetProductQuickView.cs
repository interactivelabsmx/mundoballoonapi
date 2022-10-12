using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Product;
using MundoBalloonApi.infrastructure.Data.Models;
using Product = MundoBalloonApi.business.DTOs.Entities.Product;
using Variant = MundoBalloonApi.business.DTOs.Entities.Variant;
using VariantValue = MundoBalloonApi.business.DTOs.Entities.VariantValue;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public async Task<ProductQuickView> GetProductQuickView([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productId)
    {
        var productQuery = await mundoBalloonContext.Products
            .Where(p => p.ProductId == productId)
            .Include(p => p.ProductCategory)
            .Include(p => p.ProductVariants)
            .ThenInclude(pv => pv.ProductVariantMedia)
            .FirstOrDefaultAsync();

        var variantValuesQuery = (
                from p in mundoBalloonContext.Products
                where p.ProductId == productId
                join pv in mundoBalloonContext.ProductVariants on p.ProductId equals pv.ProductId
                join pvv in mundoBalloonContext.ProductVariantValues on pv.ProductVariantId equals pvv.ProductVariantId
                join vv in mundoBalloonContext.VariantValues on pvv.VariantValueId equals vv.VariantValueId
                select vv)
            .Distinct()
            .AsEnumerable();

        var variantsQuery = (
                from v in mundoBalloonContext.Variants
                join vv in variantValuesQuery on v.VariantId equals vv.VariantId
                select v)
            .Distinct()
            .Include(v => v.UiRegistry)
            .AsEnumerable();

        return new ProductQuickView
        {
            Product = mapper.Map<Product>(productQuery),
            Variants = mapper.Map<List<Variant>>(variantsQuery),
            VariantValues = mapper.Map<List<VariantValue>>(variantValuesQuery)
        };
    }
}