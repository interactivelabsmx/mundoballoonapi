namespace MundoBalloonApi.business.DTOs.Entities;

public class ProductVariantMedium : BaseDto
{
    public int ProductVariantMediaId { get; set; } = 0;
    public int ProductVariantId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string MediaType { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Quality { get; set; } = string.Empty;

    public ProductVariant? ProductVariant { get; set; }
}