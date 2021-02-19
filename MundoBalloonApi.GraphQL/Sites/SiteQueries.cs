using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.Dtos;

namespace MundoBalloonApi.graphql.Sites
{
    [ExtendObjectType(Name = "Query")]
    public class SiteQueries
    {
        public Task<Site> GetAllSiteProducts(int first, List<int>? entityIds, bool products, bool featuredProducts, 
            bool bestSellingProducts, bool newestProducts, [Service] ISiteService siteService)
        {
            return siteService.GetAllSiteProducts(products, featuredProducts, bestSellingProducts, newestProducts);
        }
    }
}