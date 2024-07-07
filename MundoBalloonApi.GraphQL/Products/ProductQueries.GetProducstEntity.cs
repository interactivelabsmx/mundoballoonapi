using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    
    [UsePaging]
    [UseSorting]
    public IQueryable<ProductEntity> GetProductsEntity(MundoBalloonContext mundoBalloonContext)
    {
        return mundoBalloonContext.Products.Select(p => new ProductEntity
        {
            ProductId = p.ProductId,
            Name = p.ProductName,
            Description = p.ProductDescription,
            Price = p.Price,
            ProductCategoryId = p.ProductCategoryId
        });
    }
}