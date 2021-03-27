using System.Linq;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IDbContextFactory<MundoBalloonContext> _contextFactory;

        public ProductsRepository(IDbContextFactory<MundoBalloonContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IQueryable<Product> GetProducts()
        {
            var context = _contextFactory.CreateDbContext();
            return context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductVariants)
                .ThenInclude(pv => pv.ProductVariantMedia)
                .IgnoreAutoIncludes()
                .AsSplitQuery();
        }
    }
}