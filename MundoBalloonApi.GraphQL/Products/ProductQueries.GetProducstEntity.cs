using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    [UsePaging]
    [UseSorting]
    public IQueryable<ProductEntity> GetProductsEntity([ScopedService] MundoBalloonContext mundoBalloonContext)
    {
        return mundoBalloonContext.Products.Select(p => new ProductEntity
        {
            ProductId = p.ProductId,
            Name = p.ProductName ?? string.Empty,
            Description = p.ProductDescription ?? string.Empty,
            Price = p.Price,
            ProductCategoryId = p.ProductCategoryId
        });
    }
}