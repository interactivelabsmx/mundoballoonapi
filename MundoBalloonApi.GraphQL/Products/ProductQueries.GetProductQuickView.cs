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
    public async Task<Product> GetProductQuickView(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productId)
    {
        var productQuery = await mundoBalloonContext.Products
            .Where(p => p.ProductId == productId)
            .Include(p => p.ProductCategory)
            .Include(p => p.ProductVariants)
            .ThenInclude(pv => pv.ProductVariantMedia)
            .FirstOrDefaultAsync();

        return mapper.Map<Product>(productQuery);
    }
}