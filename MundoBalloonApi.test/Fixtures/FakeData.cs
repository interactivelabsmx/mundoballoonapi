using Bogus;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.test.Fixtures;

public class FakeData
{
    private static readonly string[] MediaTypes = { "Image", "Video" };
    private static readonly string[] MediaQuality = { "high", "low" };
    private static readonly string[] VariantType = { "string", "number", "boolean" };

    private readonly Faker<ProductCategory> _productCategoryFaker;

    private readonly Faker<User> _userFaker;

    private readonly Faker<VariantsType> _variantsTypeFaker;

    private Faker<Product>? _productFaker;

    private Faker<ProductVariant>? _productVariantFaker;

    private Faker<ProductVariantMedium>? _productVariantMediumFaker;

    private Faker<ProductVariantReview>? _productVariantReviewFaker;

    private Faker<Variant>? _variantFaker;

    private Faker<VariantValue>? _variantValueFaker;

    public FakeData()
    {
        _variantsTypeFaker = VariantsTypeFakerBuilder();
        _productCategoryFaker = ProductCategoryFakerBuilder();
        _userFaker = UserFakerBuilder();
    }

    public List<VariantsType>? VariantsTypes { get; set; }
    public List<Variant>? Variants { get; set; }
    public List<VariantValue>? VariantValues { get; set; }
    public List<ProductCategory>? ProductCategories { get; set; }
    public List<Product>? Products { get; set; }
    public List<ProductVariant>? ProductVariants { get; set; }
    public List<ProductVariantMedium>? ProductVariantMedia { get; set; }
    public List<ProductVariantReview>? ProductVariantReviews { get; set; }
    public List<User>? Users { get; set; }

    private static Faker<VariantsType> VariantsTypeFakerBuilder()
    {
        return new Faker<VariantsType>()
            .RuleFor(v => v.VariantType, f => f.PickRandom(VariantType));
    }

    private VariantsType MakeVariantsType(int seed)
    {
        return _variantsTypeFaker?.UseSeed(seed).Generate() ?? new VariantsType();
    }

    public List<VariantsType> MakeVariantsTypes(int count = 10)
    {
        return Enumerable.Range(1, count).Select(MakeVariantsType).ToList();
    }

    private static Faker<Variant> VariantFakerBuilder(List<VariantsType> variantsTypes)
    {
        return new Faker<Variant>()
            .RuleFor(v => v.Variant1, f => f.Commerce.Department())
            .RuleFor(v => v.VariantType, f => f.PickRandom(variantsTypes));
    }

    private Variant MakeVariant(int seed)
    {
        return _variantFaker?.UseSeed(seed).Generate() ?? new Variant();
    }

    public List<Variant> MakeVariants(List<VariantsType> variantsTypes, int count = 10)
    {
        _variantFaker ??= VariantFakerBuilder(variantsTypes);
        return Enumerable.Range(1, count).Select(MakeVariant).ToList();
    }

    private static Faker<VariantValue>? VariantValueFakerBuilder(List<Variant> variants)
    {
        return new Faker<VariantValue>()
            .RuleFor(vv => vv.VariantValue1, f => f.Commerce.Color())
            .RuleFor(vv => vv.VariantId, f => f.PickRandom(variants).VariantId)
            .RuleFor(vv => vv.Variant, f => f.PickRandom(variants));
    }

    private VariantValue MakeVariantValue(int seed)
    {
        return _variantValueFaker?.UseSeed(seed).Generate() ?? new VariantValue();
    }

    public List<VariantValue> MakeVariantValues(List<Variant> variants, int count = 10)
    {
        _variantValueFaker ??= VariantValueFakerBuilder(variants);
        return Enumerable.Range(1, count).Select(MakeVariantValue).ToList();
    }

    private static Faker<ProductCategory> ProductCategoryFakerBuilder()
    {
        return new Faker<ProductCategory>()
            .RuleFor(pc => pc.ProductCategoryName, f => f.Commerce.Categories(1).First())
            .RuleFor(pc => pc.ProductCategoryDescription, f => f.Commerce.Categories(1).First());
    }

    private ProductCategory MakeProductCategory(int seed)
    {
        return _productCategoryFaker.UseSeed(seed).Generate();
    }

    public List<ProductCategory> MakeProductCategories(int count = 10)
    {
        return Enumerable.Range(1, count).Select(MakeProductCategory).ToList();
    }

    private static Faker<Product>? ProductFakerBuilder(List<ProductCategory> productCategories)
    {
        return new Faker<Product>()
            .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
            .RuleFor(p => p.ProductDescription, f => f.Commerce.ProductAdjective())
            .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()))
            .RuleFor(p => p.ProductCategoryId, f => f.PickRandom(productCategories).ProductCategoryId);
    }

    private Product MakeProduct(int seed)
    {
        return _productFaker?.UseSeed(seed).Generate() ?? new Product();
    }

    public List<Product> MakeProducts(List<ProductCategory> productCategories, int count = 10)
    {
        _productFaker ??= ProductFakerBuilder(productCategories);
        return Enumerable.Range(1, count).Select(MakeProduct).ToList();
    }

    private static Faker<ProductVariant>? ProductVariantFakerBuilder(List<Product> products)
    {
        return new Faker<ProductVariant>()
            .RuleFor(pv => pv.Sku, f => f.Commerce.Ean13())
            .RuleFor(p => p.ProductVariantName, f => f.Commerce.ProductName())
            .RuleFor(p => p.ProductVariantDescription, f => f.Commerce.ProductAdjective())
            .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()))
            .RuleFor(p => p.ProductId, f => f.PickRandom(products).ProductId);
    }

    private ProductVariant MakeProductVariant(int seed)
    {
        return _productVariantFaker?.UseSeed(seed).Generate() ?? new ProductVariant();
    }

    public List<ProductVariant> MakeProductVariants(List<Product> products, int count = 10)
    {
        _productVariantFaker ??= ProductVariantFakerBuilder(products);
        return Enumerable.Range(1, count).Select(MakeProductVariant).ToList();
    }

    private static Faker<ProductVariantReview>? ProductVariantReviewFakerBuilder(List<ProductVariant> productVariants,
        List<User> users)
    {
        var rnd = new Random();
        return new Faker<ProductVariantReview>()
            .RuleFor(pvr => pvr.Comments, f => f.Rant.Review())
            .RuleFor(pvr => pvr.Rating, _ => rnd.Next(1, 5))
            .RuleFor(pvr => pvr.ProductVariantId, f => f.PickRandom(productVariants).ProductVariantId)
            .RuleFor(pvr => pvr.UserId, f => f.PickRandom(users).UserId);
    }

    private ProductVariantReview MakeProductVariantReview(int seed)
    {
        return _productVariantReviewFaker?.UseSeed(seed).Generate() ?? new ProductVariantReview();
    }

    public List<ProductVariantReview> MakeProductVariantReviews(List<ProductVariant> productVariants, List<User> users,
        int count = 10)
    {
        _productVariantReviewFaker ??= ProductVariantReviewFakerBuilder(productVariants, users);
        return Enumerable.Range(1, count).Select(MakeProductVariantReview).ToList();
    }

    private static Faker<ProductVariantMedium>? ProductVariantMediumFakerBuilder(List<ProductVariant> productVariants)
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
        return _productVariantMediumFaker?.UseSeed(seed).Generate() ?? new ProductVariantMedium();
    }

    public List<ProductVariantMedium> MakeProductVariantMedia(List<ProductVariant> productVariants, int count = 10)
    {
        _productVariantMediumFaker = ProductVariantMediumFakerBuilder(productVariants);
        return Enumerable.Range(1, count).Select(MakeProductVariantMedium).ToList();
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

    public List<User> MakeUsers(int count = 10)
    {
        return Enumerable.Range(1, count).Select(MakeUser).ToList();
    }
}