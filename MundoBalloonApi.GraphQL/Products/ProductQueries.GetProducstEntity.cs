using AutoMapper;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [UseDbContext(typeof(MundoBalloonContext))]
    [UsePaging(IncludeTotalCount = true)]
    [UseSorting]
    public IQueryable<ProductEntity> GetProductsEntity([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        var products = mundoBalloonContext.Products.Select(p => new ProductEntity()
        {
            ProductId = p.ProductId,
            Name = p.ProductName ?? string.Empty,
            Description = p.ProductDescription ?? string.Empty,
            Price = p.Price,
            ProductCategoryId = p.ProductCategoryId
        });
        return products;
    }
}