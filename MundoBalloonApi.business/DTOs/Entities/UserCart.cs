namespace MundoBalloonApi.business.DTOs.Entities;

public class UserCart : BaseDto
{
    public string UserId { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public int ProductVariantId { get; set; }
    public ProductVariant? Variant { get; set; }
}