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

    public async Task<ProductCategory> CreateProductCategory(ProductCategory productCategory,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.ProductCategories.Add(productCategory);
            await context.SaveChangesAsync(cancellationToken);
        }

        return productCategory;
    }

    public async Task<Variant> CreateVariant(Variant variant, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.Variants.Add(variant);
            await context.SaveChangesAsync(cancellationToken);
        }

        return variant;
    }

    public async Task<VariantValue> CreateVariantValue(VariantValue variant, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.VariantValues.Add(variant);
            await context.SaveChangesAsync(cancellationToken);
        }

        return variant;
    }

    public async Task<VariantsType> CreateVariantsType(VariantsType variantsType, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.VariantsTypes.Add(variantsType);
            await context.SaveChangesAsync(cancellationToken);
        }

        return variantsType;
    }
}