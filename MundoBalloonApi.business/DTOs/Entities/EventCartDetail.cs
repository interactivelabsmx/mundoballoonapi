namespace MundoBalloonApi.business.DTOs.Entities;

public class EventCartDetail : BaseDto
{
    public int EventCartId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int ProductVariantId { get; set; }
    public int? UserEventId { get; init; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public string Label { get; set; } = string.Empty;

    public ProductVariant? Variant { get; set; }
    public UserEvent? UserEvent { get; set; }
}