using Microsoft.AspNetCore.Authorization;

namespace MundoBalloonApi.graphql.Site;

[ExtendObjectType(Name = "Query")]
public partial class SiteQueries
{
    [Authorize]
    public string[] GetSortOptions()
    {
        return new[] { "Price", "Newest" };
    }
}