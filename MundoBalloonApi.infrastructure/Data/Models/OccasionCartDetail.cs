namespace MundoBalloonApi.infrastructure.Data.Models;

public class OccasionCartDetail : BaseEntity
{
    public int OccasionCartId { get; init; }
    public string? Sku { get; init; }
    public int ProductVariantId { get; init; }
    public double Quantity { get; init; }
    public double Price { get; init; }
    public string? Label { get; init; }

    public OccasionCart? OccasionCart { get; set; }
    public ProductVariant? ProductVariant { get; set; }
    public ProductVariant? SkuNavigation { get; set; }
}