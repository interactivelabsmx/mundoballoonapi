using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Site
{
    [ExtendObjectType(Name = "Query")]
    public class SiteQueries
    {
        public async Task<business.DTOs.Models.Site> GetSite([Service] ISiteService siteService)
        {
            return await siteService.GetSite(true, true, true, true);
        }
    }
}