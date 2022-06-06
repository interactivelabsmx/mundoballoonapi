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

    public Product CreateProduct(Product product)
    {
        var context = _contextFactory.CreateDbContext();
        using (context)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        return product;
    }

    public bool DeleteProduct(int productId)
    {
        var context = _contextFactory.CreateDbContext();
        var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
        if (product != null)
        {
            context.Products.Remove(product);
            var productVariants = context.ProductVariants.Where(pv => pv.ProductId == productId).ToList();
            if (productVariants.Count > 0) context.ProductVariants.RemoveRange(productVariants);
            context.SaveChanges();
            return true;
        }

        return false;
    }

    public bool DeleteProductVariant(int productVariantId)
    {
        var context = _contextFactory.CreateDbContext();
        var productVariant = context.ProductVariants.FirstOrDefault(p => p.ProductVariantId == productVariantId);
        if (productVariant != null)
        {
            context.ProductVariants.Remove(productVariant);
            context.SaveChanges();
            return true;
        }

        return false;
    }

    public Product UpdateProduct(Product product)
    {
        var context = _contextFactory.CreateDbContext();
        using (context)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        return product;
    }

    public ProductVariant CreateProductVariant(ProductVariant productVariant)
    {
        var context = _contextFactory.CreateDbContext();
        context.ProductVariants.Add(productVariant);
        context.SaveChanges();
        return productVariant;
    }

    public ProductVariant ProductVariantAddValue(ProductVariantValue variantValue)
    {
        var context = _contextFactory.CreateDbContext();
        var productVariant = context.ProductVariants.First(pv => pv.ProductVariantId == variantValue.ProductVariantId);
        productVariant.ProductVariantValues.Add(variantValue);
        context.SaveChanges();
        return productVariant;
    }

    public bool DeleteProductVariantValue(int productVariantId, int variantId, int variantValueId)
    {
        var context = _contextFactory.CreateDbContext();
        var value = context.ProductVariantValues.FirstOrDefault(pvv =>
            pvv.ProductVariantId == productVariantId && pvv.VariantId == variantId &&
            pvv.VariantValueId == variantValueId);
        if (value != null)
        {
            context.ProductVariantValues.Remove(value);
            context.SaveChanges();
            return true;
        }

        return false;
    }

    public ProductVariant ProductVariantAddMedia(ProductVariantMedium variantMedia)
    {
        var context = _contextFactory.CreateDbContext();
        var productVariant = context.ProductVariants.First(pv => pv.ProductVariantId == variantMedia.ProductVariantId);
        productVariant.ProductVariantMedia.Add(variantMedia);
        context.SaveChanges();
        return productVariant;
    }

    public bool DeleteProductVariantMedia(int productVariantMediaId)
    {
        var context = _contextFactory.CreateDbContext();
        var media = context.ProductVariantMedia.FirstOrDefault(p => p.ProductVariantMediaId == productVariantMediaId);
        if (media != null)
        {
            context.ProductVariantMedia.Remove(media);
            context.SaveChanges();
            return true;
        }

        return false;
    }

    public ProductVariant? GetProductVariantById(int productVariantId)
    {
        var context = _contextFactory.CreateDbContext();
        return context.ProductVariants.FirstOrDefault(pv => pv.ProductVariantId == productVariantId);
    }

    public ProductVariant UpdateProductVariant(ProductVariant productVariant)
    {
        var context = _contextFactory.CreateDbContext();
        using (context)
        {
            context.ProductVariants.Update(productVariant);
            context.SaveChanges();
        }

        return productVariant;
    }
}