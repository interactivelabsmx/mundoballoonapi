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

    public async Task<Product> CreateProduct(Product product, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync(cancellationToken);
        }

        return product;
    }

    public async Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var product = await context.Products.FirstOrDefaultAsync(p => p.ProductId == productId, cancellationToken);
        if (product == null) return false;
        context.Products.Remove(product);
        var productVariants = context.ProductVariants.Where(pv => pv.ProductId == productId).ToList();
        if (productVariants.Count > 0) context.ProductVariants.RemoveRange(productVariants);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteProductVariant(int productVariantId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var productVariant =
            await context.ProductVariants.FirstOrDefaultAsync(p => p.ProductVariantId == productVariantId,
                cancellationToken);
        if (productVariant == null) return false;
        context.ProductVariants.Remove(productVariant);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Product> UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync(cancellationToken);
        }

        return product;
    }

    public async Task<ProductVariant> CreateProductVariant(ProductVariant productVariant,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        context.ProductVariants.Add(productVariant);
        await context.SaveChangesAsync(cancellationToken);
        return productVariant;
    }

    public async Task<ProductVariant> ProductVariantAddValue(ProductVariantValue variantValue,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var productVariant =
            await context.ProductVariants.FirstAsync(pv => pv.ProductVariantId == variantValue.ProductVariantId,
                cancellationToken);
        productVariant.ProductVariantValues.Add(variantValue);
        await context.SaveChangesAsync(cancellationToken);
        return productVariant;
    }

    public async Task<bool> DeleteProductVariantValue(int productVariantId, int variantId, int variantValueId,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var value = await context.ProductVariantValues.FirstOrDefaultAsync(pvv =>
            pvv.ProductVariantId == productVariantId && pvv.VariantId == variantId &&
            pvv.VariantValueId == variantValueId, cancellationToken);
        if (value == null) return false;
        context.ProductVariantValues.Remove(value);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<ProductVariant> ProductVariantAddMedia(ProductVariantMedium variantMedia,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var productVariant =
            await context.ProductVariants.FirstAsync(pv => pv.ProductVariantId == variantMedia.ProductVariantId,
                cancellationToken);
        productVariant.ProductVariantMedia.Add(variantMedia);
        await context.SaveChangesAsync(cancellationToken);
        return productVariant;
    }

    public async Task<bool> DeleteProductVariantMedia(int productVariantMediaId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var media = await context.ProductVariantMedia.FirstOrDefaultAsync(p =>
            p.ProductVariantMediaId == productVariantMediaId, cancellationToken);
        if (media == null) return false;
        context.ProductVariantMedia.Remove(media);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<ProductVariant> UpdateProductVariant(ProductVariant productVariant,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.ProductVariants.Update(productVariant);
            await context.SaveChangesAsync(cancellationToken);
        }

        return productVariant;
    }

    public async Task<ProductVariantReview> AddProductVariantReview(ProductVariantReview variantReview,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.Add(variantReview);
            await context.SaveChangesAsync(cancellationToken);
        }

        return variantReview;
    }

    public async Task<ProductVariantReview> UpdateProductVariantReview(ProductVariantReview productVariantReview,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.ProductVariantReviews.Update(productVariantReview);
            await context.SaveChangesAsync(cancellationToken);
        }

        return productVariantReview;
    }

    public async Task<bool> DeleteProductVariantReview(int productVariantReviewId, string userId,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var productVariantReview = await context.ProductVariantReviews.FirstOrDefaultAsync(
            u => u.UserId == userId && u.ProductVariantId == productVariantReviewId, cancellationToken);
        if (productVariantReview == null) return false;
        context.ProductVariantReviews.Remove(productVariantReview);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IQueryable<UserCartProduct>> GetUserCartProducts(string userId,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        return context.UserCartProducts.Where(up => up.UserId == userId);
    }

    public async Task<bool> DeleteUserCartProducts(IEnumerable<UserCartProduct> entities,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.UserCartProducts.RemoveRange(entities);
            await context.SaveChangesAsync(cancellationToken);
        }

        return true;
    }
}