using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.Dtos;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.business.Services
{
    public class SiteService : ISiteService
    {
        private readonly IDbContextFactory<MundoBalloonContext> _contextFactory;

        public SiteService(IDbContextFactory<MundoBalloonContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Site> GetAllSiteProducts(bool includeProducts, bool includeFeaturedProducts, bool includeBestSellingProducts, 
            bool includeNewestProducts)
        {
            var site = new Site();
            if (includeProducts) using (var context = _contextFactory.CreateDbContext())
            {
                 site.Products = await context.Products.ToListAsync();
            }

            if (includeFeaturedProducts)using (var context = _contextFactory.CreateDbContext())
            {
                site.FeaturedProducts = await context.Products.ToListAsync();
            }

            if (includeBestSellingProducts) using (var context = _contextFactory.CreateDbContext())
            {
                site.BestSellingProducts = await context.Products.ToListAsync();
            }

            if (includeNewestProducts) using (var context = _contextFactory.CreateDbContext())
            {
                site.NewestProducts = await context.Products.ToListAsync();
            }

            return site;
        }
    }
}