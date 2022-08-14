using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Repositories;

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

    public async Task<Product> CreateProduct(Product product)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        await using (context)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
        }

        return product;
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        var product = await context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        if (product == null) return false;
        context.Products.Remove(product);
        var productVariants = context.ProductVariants.Where(pv => pv.ProductId == productId).ToList();
        if (productVariants.Count > 0) context.ProductVariants.RemoveRange(productVariants);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteProductVariant(int productVariantId)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        var productVariant =
            await context.ProductVariants.FirstOrDefaultAsync(p => p.ProductVariantId == productVariantId);
        if (productVariant == null) return false;
        context.ProductVariants.Remove(productVariant);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        await using (context)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }

        return product;
    }

    public async Task<ProductVariant> CreateProductVariant(ProductVariant productVariant)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        context.ProductVariants.Add(productVariant);
        await context.SaveChangesAsync();
        return productVariant;
    }

    public async Task<ProductVariant> ProductVariantAddValue(ProductVariantValue variantValue)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        var productVariant =
            await context.ProductVariants.FirstAsync(pv => pv.ProductVariantId == variantValue.ProductVariantId);
        productVariant.ProductVariantValues.Add(variantValue);
        await context.SaveChangesAsync();
        return productVariant;
    }

    public async Task<bool> DeleteProductVariantValue(int productVariantId, int variantId, int variantValueId)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        var value = await context.ProductVariantValues.FirstOrDefaultAsync(pvv =>
            pvv.ProductVariantId == productVariantId && pvv.VariantId == variantId &&
            pvv.VariantValueId == variantValueId);
        if (value == null) return false;
        context.ProductVariantValues.Remove(value);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<ProductVariant> ProductVariantAddMedia(ProductVariantMedium variantMedia)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        var productVariant =
            await context.ProductVariants.FirstAsync(pv => pv.ProductVariantId == variantMedia.ProductVariantId);
        productVariant.ProductVariantMedia.Add(variantMedia);
        await context.SaveChangesAsync();
        return productVariant;
    }

    public async Task<bool> DeleteProductVariantMedia(int productVariantMediaId)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        var media = await context.ProductVariantMedia.FirstOrDefaultAsync(p =>
            p.ProductVariantMediaId == productVariantMediaId);
        if (media == null) return false;
        context.ProductVariantMedia.Remove(media);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<ProductVariant> UpdateProductVariant(ProductVariant productVariant)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        await using (context)
        {
            context.ProductVariants.Update(productVariant);
            await context.SaveChangesAsync();
        }

        return productVariant;
    }
}