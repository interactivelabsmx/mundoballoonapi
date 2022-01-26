namespace MundoBalloonApi.infrastructure.Data.Models;

public class OcassionCartDetail : BaseEntity
{
    public int OccasionCartId { get; set; }
    public string? Sku { get; set; }
    public int ProductVariantId { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public string? Label { get; set; }

    public virtual OccasionCart? OccasionCart { get; set; }
    public virtual ProductVariant? ProductVariant { get; set; }
    public virtual ProductVariant? SkuNavigation { get; set; }
}