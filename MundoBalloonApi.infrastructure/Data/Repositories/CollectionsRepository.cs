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

    public async Task<ProductCategory> CreateProductCategory(ProductCategory productCategory)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        await using (context)
        {
            context.ProductCategories.Add(productCategory);
            await context.SaveChangesAsync();
        }

        return productCategory;
    }

    public async Task<Variant> CreateVariant(Variant variant)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        await using (context)
        {
            context.Variants.Add(variant);
            await context.SaveChangesAsync();
        }

        return variant;
    }

    public async Task<VariantValue> CreateVariantValue(VariantValue variant)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        await using (context)
        {
            context.VariantValues.Add(variant);
            await context.SaveChangesAsync();
        }

        return variant;
    }
}