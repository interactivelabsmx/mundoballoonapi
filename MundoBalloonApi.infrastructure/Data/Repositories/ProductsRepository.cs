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
}