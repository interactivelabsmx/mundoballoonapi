namespace MundoBalloonApi.business.DTOs.Entities;

public class OccasionCartDetail
{
    public int OccasionCartId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int ProductVariantId { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public string Label { get; set; } = string.Empty;

    public ProductVariant? Variant { get; set; }
}