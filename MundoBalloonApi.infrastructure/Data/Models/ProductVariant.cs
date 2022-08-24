namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductVariant : BaseEntity
{
    public int ProductVariantId { get; init; }
    public string? Sku { get; init; }
    public int ProductId { get; init; }
    public string? ProductVariantName { get; init; }
    public string? ProductVariantDescription { get; init; }
    public double Price { get; init; }
    public Product? Product { get; set; }

    public ICollection<EventCartDetail> EventCartDetailProductVariants { get; set; } =
        new HashSet<EventCartDetail>();

    public ICollection<EventCartDetail> EventCartDetailSkuNavigations { get; set; } =
        new HashSet<EventCartDetail>();

    public ICollection<ProductVariantMedium> ProductVariantMedia { get; set; } = new HashSet<ProductVariantMedium>();
    public ICollection<ProductVariantValue> ProductVariantValues { get; set; } = new HashSet<ProductVariantValue>();
    public ICollection<UserCart> UserCartProductVariants { get; set; } = new HashSet<UserCart>();
    public ICollection<UserCart> UserCartSkuNavigations { get; set; } = new HashSet<UserCart>();
    public ICollection<ProductVariantReview> ProductVariantReviews { get; set; } = new HashSet<ProductVariantReview>();
}