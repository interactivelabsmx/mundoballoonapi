using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using Product = MundoBalloonApi.business.DataObjects.Entities.Product;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [UseDbContext(typeof(MundoBalloonContext))]
    public Product? GetProductById([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productId)
    {
        var product = mundoBalloonContext.Products
            .Include(p => p.ProductCategory)
            .Include(p => p.ProductVariants)
            .ThenInclude(pv => pv.ProductVariantMedia)
            .IgnoreAutoIncludes()
            .FirstOrDefault(p => p.ProductId == productId);
        return product != null ? mapper.Map<Product>(product) : null;
    }
}