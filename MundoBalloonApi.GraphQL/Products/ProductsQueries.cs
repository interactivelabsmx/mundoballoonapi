using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Products
{
    [ExtendObjectType(Name = "Query")]
    public class ProductsQueries
    {
        [UseDbContext(typeof(MundoBalloonContext))]
        public IQueryable<Product> GetAllProducts([ScopedService] MundoBalloonContext mundoBalloonContext)
        {
            return mundoBalloonContext.Products;
        }
    }
}