using AutoMapper;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductCategory = MundoBalloonApi.business.DataObjects.Entities.ProductCategory;

namespace MundoBalloonApi.graphql.Collections;

[ExtendObjectType(Name = "Query")]
public class CollectionQueries
{
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<ProductCategory> GetProductCategories([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        var products = mundoBalloonContext.ProductCategories;
        return mapper.ProjectTo<ProductCategory>(products);
    }

    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<CountryCode> GetCountryCodes([ScopedService] MundoBalloonContext mundoBalloonContext)
    {
        return mundoBalloonContext.CountryCodes.Where(cc => cc.Supported == true);
    }
}