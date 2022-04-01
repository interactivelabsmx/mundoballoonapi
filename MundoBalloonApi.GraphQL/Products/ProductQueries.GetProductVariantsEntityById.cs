using AutoMapper;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<ProductVariantEntity> GetProductVariantsEntityById(
        [ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productId)
    {
        var products = mundoBalloonContext.ProductVariants.Where(pv => pv.ProductId == productId).Select(p =>
            new ProductVariantEntity
            {
                ProductVariantId = p.ProductVariantId,
                Sku = p.Sku ?? string.Empty,
                ProductId = p.ProductId,
                Price = p.Price,
                Name = p.ProductVariantName ?? string.Empty,
                Description = p.ProductVariantDescription ?? string.Empty
            });
        return products;
    }
}