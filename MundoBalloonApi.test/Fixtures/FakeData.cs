using Bogus;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.test.Fixtures;

public class FakeData
{
    private static readonly string[] MediaTypes = { "Image", "Video" };
    private static readonly string[] MediaQuality = { "high", "low" };
    private static readonly string[] VariantType = { "string", "number", "boolean" };

    private readonly Faker<ProductCategory> _productCategoryFaker;

    private readonly Faker<Product> _productFaker;

    private readonly Faker<ProductVariant> _productVariantFaker;

    private readonly Faker<ProductVariantMedium> _productVariantMediumFaker;

    private readonly Faker<User> _userFaker;

    private readonly Faker<Variant> _variantFaker;

    private readonly Faker<VariantValue> _variantValueFaker;

    public FakeData()
    {
        _variantFaker = VariantFakerBuilder();
        Variants = Enumerable.Range(1, 5).Select(MakeVariant).ToList();
        _variantValueFaker = VariantValueFakerBuilder(Variants);
        VariantValues = Enumerable.Range(1, 10).Select(MakeVariantValue).ToList();
        _productCategoryFaker = ProductCategoryFakerBuilder();
        ProductCategories = Enumerable.Range(1, 5).Select(MakeProductCategory).ToList();
        _productFaker = ProductFakerBuilder(ProductCategories);
        Products = Enumerable.Range(1, 10).Select(MakeProduct).ToList();
        _productVariantFaker = ProductVariantFakerBuilder(Products);
        ProductVariants = Enumerable.Range(1, 20).Select(MakeProductVariant).ToList();
        _productVariantMediumFaker = ProductVariantMediumFakerBuilder(ProductVariants);
        ProductVariantMedia = Enumerable.Range(1, 50).Select(MakeProductVariantMedium).ToList();
        _userFaker = UserFakerBuilder();
        Users = Enumerable.Range(1, 10).Select(MakeUser).ToList();
    }

    public List<Variant> Variants { get; }
    public List<VariantValue> VariantValues { get; }
    public List<ProductCategory> ProductCategories { get; }
    public List<Product> Products { get; }
    public List<ProductVariant> ProductVariants { get; }
    public List<ProductVariantMedium> ProductVariantMedia { get; }
    public List<User> Users { get; }

    private static Faker<Variant> VariantFakerBuilder()
    {
        return new Faker<Variant>()
            .RuleFor(v => v.Variant1, f => f.Commerce.Department())
            .RuleFor(v => v.VariantType, f => f.PickRandom(VariantType));
    }

    private Variant MakeVariant(int seed)
    {
        return _variantFaker.UseSeed(seed).Generate();
    }

    private static Faker<VariantValue> VariantValueFakerBuilder(List<Variant> variants)
    {
        return new Faker<VariantValue>()
            .RuleFor(vv => vv.VariantValue1, f => f.Commerce.Color())
            .RuleFor(vv => vv.VariantId, faker => faker.PickRandom(variants).VariantId);
    }

    private VariantValue MakeVariantValue(int seed)
    {
        return _variantValueFaker.UseSeed(seed).Generate();
    }

    private static Faker<ProductCategory> ProductCategoryFakerBuilder()
    {
        return new Faker<ProductCategory>()
            .RuleFor(pc => pc.ProductCategoryName, f => f.Commerce.Categories(1)[0])
            .RuleFor(pc => pc.ProductCategoryDescription, f => f.Commerce.Categories(1)[0]);
    }

    private ProductCategory MakeProductCategory(int seed)
    {
        return _productCategoryFaker.UseSeed(seed).Generate();
    }

    private static Faker<Product> ProductFakerBuilder(List<ProductCategory> productCategories)
    {
        return new Faker<Product>()
            .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
            .RuleFor(p => p.ProductDescription, f => f.Commerce.ProductAdjective())
            .RuleFor(p => p.Price, f => double.Parse(f.Commerce.Price()))
            .RuleFor(p => p.ProductCategoryId, f => f.PickRandom(productCategories).ProductCategoryId);
    }

    private Product MakeProduct(int seed)
    {
        return _productFaker.UseSeed(seed).Generate();
    }

    private static Faker<ProductVariant> ProductVariantFakerBuilder(List<Product> products)
    {
        return new Faker<ProductVariant>()
            .RuleFor(pv => pv.Sku, f => f.Commerce.Ean13())
            .RuleFor(p => p.ProductVariantName, f => f.Commerce.ProductName())
            .RuleFor(p => p.ProductVariantDescription, f => f.Commerce.ProductAdjective())
            .RuleFor(p => p.Price, f => double.Parse(f.Commerce.Price()))
            .RuleFor(p => p.ProductId, f => f.PickRandom(products).ProductId);
    }

    private ProductVariant MakeProductVariant(int seed)
    {
        return _productVariantFaker.UseSeed(seed).Generate();
    }

    private static Faker<ProductVariantMedium> ProductVariantMediumFakerBuilder(List<ProductVariant> productVariants)
    {
        return new Faker<ProductVariantMedium>()
            .RuleFor(pvm => pvm.Name, f => f.Commerce.ProductName())
            .RuleFor(pvm => pvm.Description, f => f.Commerce.ProductAdjective())
            .RuleFor(pvm => pvm.MediaType, f => f.PickRandom(MediaTypes))
            .RuleFor(pvm => pvm.Quality, f => f.PickRandom(MediaQuality))
            .RuleFor(pvm => pvm.Url, f => f.Image.PlaceholderUrl(100, 150))
            .RuleFor(pvm => pvm.ProductVariantId, f => f.PickRandom(productVariants).ProductVariantId);
    }

    private ProductVariantMedium MakeProductVariantMedium(int seed)
    {
        return _productVariantMediumFaker.UseSeed(seed).Generate();
    }

    private static Faker<User> UserFakerBuilder()
    {
        var userId = 0;
        return new Faker<User>()
            .RuleFor(u => u.UserId, _ => (userId++).ToString());
    }

    private User MakeUser(int seed)
    {
        return _userFaker.UseSeed(seed).Generate();
    }
}