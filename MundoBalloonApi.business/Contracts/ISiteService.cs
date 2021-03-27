using System.Threading.Tasks;
using MundoBalloonApi.business.DTOs.Models;

namespace MundoBalloonApi.business.Contracts
{
    public interface ISiteService
    {
        Task<Site> GetSite(bool includeProducts, bool includeFeaturedProducts, bool includeBestSellingProducts,
            bool includeNewestProducts);
    }
}