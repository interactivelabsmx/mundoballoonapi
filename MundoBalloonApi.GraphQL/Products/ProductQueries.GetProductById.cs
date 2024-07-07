using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using Product = MundoBalloonApi.business.DTOs.Entities.Product;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    
    public async Task<Product?> GetProductById(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productId)
    {
        var productQuery = await (
                from product in mundoBalloonContext.Products
                where product.ProductId == productId
                select product
            )
            .Include(p => p.ProductCategory)
            .Include(p => p.ProductVariants)
            .ThenInclude(pv => pv.ProductVariantMedia)
            .Include(p => p.ProductVariants)
            .ThenInclude(pv => pv.ProductVariantValues)
            .ThenInclude(pvv => pvv.VariantValue)
            .Include(p => p.ProductVariants)
            .ThenInclude(pv => pv.ProductVariantReviews)
            .AsSplitQuery()
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return mapper.Map<Product>(productQuery);
    }
}