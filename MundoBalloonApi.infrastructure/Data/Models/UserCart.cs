namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserCart : BaseEntity
{
    public int? ProductVariantId { get; set; }

    public string UserId { get; set; } = null!;

    public string Sku { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual ProductVariant? ProductVariant { get; set; }

    public virtual ProductVariant SkuNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}