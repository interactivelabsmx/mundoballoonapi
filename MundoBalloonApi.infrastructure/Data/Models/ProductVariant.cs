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

    public ICollection<OccasionCartDetail> OccasionCartDetailProductVariants { get; set; } =
        new HashSet<OccasionCartDetail>();

    public ICollection<OccasionCartDetail> OccasionCartDetailSkuNavigations { get; set; } =
        new HashSet<OccasionCartDetail>();

    public ICollection<ProductVariantMedium> ProductVariantMedia { get; set; } = new HashSet<ProductVariantMedium>();
    public ICollection<ProductVariantValue> ProductVariantValues { get; set; } = new HashSet<ProductVariantValue>();
    public ICollection<UserCart> UserCartProductVariants { get; set; } = new HashSet<UserCart>();
    public ICollection<UserCart> UserCartSkuNavigations { get; set; } = new HashSet<UserCart>();
}