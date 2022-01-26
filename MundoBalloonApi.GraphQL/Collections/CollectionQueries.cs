using AutoMapper;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductCategory = MundoBalloonApi.business.DataObjects.Entities.ProductCategory;
using Variant = MundoBalloonApi.business.DataObjects.Entities.Variant;
using VariantValue = MundoBalloonApi.business.DataObjects.Entities.VariantValue;

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

    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<Variant> GetVariants([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<Variant>(mundoBalloonContext.Variants);
    }

    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<VariantValue> GetVariantValues([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int variantId)
    {
        var variantValues = mundoBalloonContext.VariantValues.Where(vv => vv.VariantId == variantId);
        return mapper.ProjectTo<VariantValue>(variantValues);
    }
}