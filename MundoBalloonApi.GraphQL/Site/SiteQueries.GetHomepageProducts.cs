using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Site;

[ExtendObjectType(Name = "Query")]
public partial class SiteQueries
{
    [Authorize]
    public async Task<IReadOnlyDictionary<string, List<Product>>> GetHomepageProducts(
        [Service] ISiteService siteService, bool includeBestSellingProducts, bool includeNewestProducts,
        CancellationToken cancellationToken)
    {
        return await siteService.GetHomepageProducts(includeBestSellingProducts, includeNewestProducts,
            cancellationToken);
    }
}