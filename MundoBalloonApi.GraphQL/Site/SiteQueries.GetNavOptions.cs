using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.SiteService;

namespace MundoBalloonApi.graphql.Site;

[ExtendObjectType(Name = "Query")]
public partial class SiteQueries
{
    [Authorize]
    public List<NavOption> GetNavOptions([Service] ISiteService siteService,
        [GlobalState("language")] string language)
    {
        return siteService.GetNavOptions(language);
    }
}