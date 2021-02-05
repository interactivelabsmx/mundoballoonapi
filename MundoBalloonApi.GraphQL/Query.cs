using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql
{
    public class Query
    {
        [UseDbContext(typeof(MundoBalloonContext))]
        public IQueryable<Product> GetAllProducts([ScopedService] MundoBalloonContext mundoBalloonContext)
        {
            return mundoBalloonContext.Products;
        }
    }
}