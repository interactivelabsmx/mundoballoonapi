using System.Threading.Tasks;
using MundoBalloonApi.business.Dtos;

namespace MundoBalloonApi.business.Contracts
{
    public interface ISiteService
    {
        Task<Site> GetAllSiteProducts(bool includeProducts, bool includeFeaturedProducts, bool includeBestSellingProducts, 
            bool includeNewestProducts);
    }
}