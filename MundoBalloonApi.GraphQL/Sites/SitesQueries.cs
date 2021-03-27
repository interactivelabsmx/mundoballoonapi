using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Models;

namespace MundoBalloonApi.graphql.Sites
{
    [ExtendObjectType(Name = "Query")]
    public class SiteQueries
    {
        public async Task<Site> GetSite([Service] ISiteService siteService)
        {
            return await siteService.GetSite(true, true, true, true);
        }
    }
}