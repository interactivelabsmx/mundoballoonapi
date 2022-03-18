using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Repositories;

public class CollectionsRepository : ICollectionsRepository
{
    private readonly IDbContextFactory<MundoBalloonContext> _contextFactory;

    public CollectionsRepository(IDbContextFactory<MundoBalloonContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public ProductCategory CreateProductCategory(ProductCategory productCategory)
    {
        var context = _contextFactory.CreateDbContext();
        using (context)
        {
            context.ProductCategories.Add(productCategory);
            context.SaveChanges();
        }

        return productCategory;
    }
}