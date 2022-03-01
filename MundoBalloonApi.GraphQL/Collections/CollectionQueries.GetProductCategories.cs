using AutoMapper;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductCategory = MundoBalloonApi.business.DataObjects.Entities.ProductCategory;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionQueries
{
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<ProductCategory> GetProductCategories([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        var productsCategories = mundoBalloonContext.ProductCategories;
        return mapper.ProjectTo<ProductCategory>(productsCategories);
    }
}