namespace MundoBalloonApi.business.DTOs.Entities;

public class UserCart
{
    public int UserId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public double Quantity { get; set; }
    public double Price { get; set; }
    public int ProductVariantId { get; set; }
    public ProductVariant? Variant { get; set; }
}