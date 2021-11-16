using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface ISiteService
{
    Task<Site> GetSite(bool includeProducts, bool includeFeaturedProducts, bool includeBestSellingProducts,
        bool includeNewestProducts);
}