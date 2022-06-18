using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Site;

[ExtendObjectType(Name = "Query")]
public class SiteQueries
{
    [AllowAnonymous]
    public async Task<business.DataObjects.Entities.Site> GetSite([Service] ISiteService siteService)
    {
        return await siteService.GetSite(true, true, true, true);
    }
}