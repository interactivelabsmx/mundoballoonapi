namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserCart : BaseEntity
{
    public string? UserId { get; init; }
    public string? Sku { get; init; }
    public double Quantity { get; init; }
    public double Price { get; init; }
    public int? ProductVariantId { get; init; }

    public ProductVariant? ProductVariant { get; set; }
    public User? User { get; set; }
}