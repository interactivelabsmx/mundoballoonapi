using AutoMapper;
using MundoBalloonApi.infrastructure.Data.Models;
using Product = MundoBalloonApi.business.DataObjects.Entities.Product;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [UseDbContext(typeof(MundoBalloonContext))]
    [UsePaging]
    [UseSorting]
    public IQueryable<Product> GetAllProducts([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<Product>(mundoBalloonContext.Products);
    }
}