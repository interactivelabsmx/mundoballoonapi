using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using Product = MundoBalloonApi.business.DTOs.Entities.Product;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Product> GetSearchProducts([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        var productQuery = from product in mundoBalloonContext.Products
            join productVariant in mundoBalloonContext.ProductVariants
                on product.ProductId equals productVariant.ProductId
            select product;
        return mapper.ProjectTo<Product>(mundoBalloonContext.Products);
    }
}