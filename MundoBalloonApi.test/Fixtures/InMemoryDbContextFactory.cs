using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.test.Fixtures;

public class InMemoryDbContextFactory : IDbContextFactory<MundoBalloonContext>
{

    public MundoBalloonContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<MundoBalloonContext>()
            .UseInMemoryDatabase("MundoBalloonContextTest:Fixtures")
            .Options;

        var context = new MundoBalloonContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var fakeData = new FakeData();

        /* COLLECTIONS */
        context.Variants.AddRange(fakeData.Variants);
        context.VariantValues.AddRange(fakeData.VariantValues);
        context.ProductCategories.AddRange(fakeData.ProductCategories);
        context.SaveChanges();

        /* PRODUCTS */
        context.Products.AddRange(fakeData.Products);
        context.ProductVariants.AddRange(fakeData.ProductVariants);
        context.SaveChanges();

        /* PRODUCT VARIANTS */
        context.ProductVariantMedia.AddRange(fakeData.ProductVariantMedia);
        context.SaveChanges();

        /* USERS */
        context.Users.AddRange(fakeData.Users);
        context.SaveChanges();

        return context;
    }
}