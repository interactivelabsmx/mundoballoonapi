using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.business.DTOs.SiteService;

namespace MundoBalloonApi.business.Contracts;

public interface ISiteService
{
    Task<IReadOnlyDictionary<string, List<Product>>> GetHomepageProducts(bool includeBestSellingProducts,
        bool includeNewestProducts);

    List<NavOption> GetNavOptions(string language);
}