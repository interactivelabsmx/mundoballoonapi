using Microsoft.AspNetCore.Authorization;

namespace MundoBalloonApi.graphql.Site;

public partial class SiteQueries
{
    [AllowAnonymous]
    public string[] GetSortOptions()
    {
        return new[] { "Price", "Newest" };
    }
}