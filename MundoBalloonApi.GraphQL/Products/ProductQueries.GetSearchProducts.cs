using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using Product = MundoBalloonApi.business.DTOs.Entities.Product;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Product> GetSearchProducts(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<Product>(mundoBalloonContext.Products);
    }
}