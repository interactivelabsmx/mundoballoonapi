using System.Linq;
using AutoMapper;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductCategory = MundoBalloonApi.business.DataObjects.Entities.ProductCategory;

namespace MundoBalloonApi.graphql.Collections
{
    [ExtendObjectType(Name = "Query")]
    public partial class CollectionQueries
    {
        [UseDbContext(typeof(MundoBalloonContext))]
        public IQueryable<ProductCategory> GetProductCategories([ScopedService] MundoBalloonContext mundoBalloonContext,
            [Service] IMapper mapper)
        {
            var products = mundoBalloonContext.ProductCategories;
            return mapper.ProjectTo<ProductCategory>(products);
        }
    }
}