namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserCartProduct : BaseEntity
{
    public string? UserId { get; init; }
    public string? Sku { get; init; }
    public decimal Quantity { get; set; }
    public decimal Price { get; init; }
    public int? ProductVariantId { get; init; }

    public ProductVariant? ProductVariant { get; set; }
    public User? User { get; set; }
}