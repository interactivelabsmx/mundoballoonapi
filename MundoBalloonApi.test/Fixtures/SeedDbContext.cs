using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.test.Fixtures;

public class SeedDbContext
{
    private readonly MundoBalloonContext _context;

    public SeedDbContext(MundoBalloonContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        var fakeData = new FakeData();

        /* COLLECTIONS */
        _context.Variants.AddRange(fakeData.Variants);
        _context.VariantValues.AddRange(fakeData.VariantValues);
        _context.ProductCategories.AddRange(fakeData.ProductCategories);
        _context.SaveChanges();

        /* PRODUCTS */
        _context.Products.AddRange(fakeData.Products);
        _context.ProductVariants.AddRange(fakeData.ProductVariants);
        _context.SaveChanges();

        /* PRODUCT VARIANTS */
        _context.ProductVariantMedia.AddRange(fakeData.ProductVariantMedia);
        _context.SaveChanges();

        /* USERS */
        _context.Users.AddRange(fakeData.Users);
        _context.SaveChanges();
    }
}