using System.Linq;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using MundoBalloonApi.business.Dtos;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql
{
    public class Query
    {
        [Authorize]
        [UseDbContext(typeof(MundoBalloonContext))]
        public IQueryable<Product> GetAllProducts([ScopedService] MundoBalloonContext mundoBalloonContext, [GlobalState] CurrentUser currentUser)
        {
            var user = currentUser;
            return mundoBalloonContext.Products;
        }
    }
}