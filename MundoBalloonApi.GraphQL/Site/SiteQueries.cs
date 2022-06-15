using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Site;

[ExtendObjectType(Name = "Query")]
public class SiteQueries
{
    public async Task<business.DataObjects.Entities.Site> GetSite([Service] ISiteService siteService) =>  await siteService.GetSite(true, true, true, true);
}