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

        /* USERS */
        fakeData.Users = fakeData.MakeUsers();
        _context.Users.AddRange(fakeData.Users);
        _context.SaveChanges();

        /* COLLECTIONS */
        fakeData.Variants = fakeData.MakeVariants();
        _context.Variants.AddRange(fakeData.Variants);
        _context.SaveChanges();

        fakeData.ProductCategories = fakeData.MakeProductCategories();
        _context.ProductCategories.AddRange(fakeData.ProductCategories);
        _context.SaveChanges();

        /* COLLECTIONS DEPENDENT */
        fakeData.VariantValues = fakeData.MakeVariantValues(fakeData.Variants);
        _context.VariantValues.AddRange(fakeData.VariantValues);
        _context.SaveChanges();

        /* PRODUCTS */
        fakeData.Products = fakeData.MakeProducts(fakeData.ProductCategories);
        _context.Products.AddRange(fakeData.Products);
        _context.SaveChanges();

        /* PRODUCT VARIANTS */
        fakeData.ProductVariants = fakeData.MakeProductVariants(fakeData.Products);
        _context.ProductVariants.AddRange(fakeData.ProductVariants);
        _context.SaveChanges();

        fakeData.ProductVariantMedia = fakeData.MakeProductVariantMedia(fakeData.ProductVariants);
        _context.ProductVariantMedia.AddRange(fakeData.ProductVariantMedia);
        _context.SaveChanges();

        fakeData.ProductVariantReviews = fakeData.MakeProductVariantReviews(fakeData.ProductVariants, fakeData.Users);
        _context.ProductVariantReviews.AddRange(fakeData.ProductVariantReviews);
        _context.SaveChanges();

        /*USER EVENTS*/
        fakeData.UserEventReviews = fakeData.MakeUserEventReviews(fakeData.UserEvents,fakeData.UserEvent);
        _context.ProductVariantReviews.AddRange(fakeData.UserEvents);
        _context.SaveChanges();
    }
}