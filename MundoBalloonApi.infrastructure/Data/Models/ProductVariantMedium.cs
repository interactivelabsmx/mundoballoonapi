namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductVariantMedium : BaseEntity
{
    public int ProductVariantMediaId { get; init; }
    public int ProductVariantId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public string? MediaType { get; init; }
    public string? Url { get; init; }
    public string? Quality { get; init; }

    public ProductVariant? ProductVariant { get; set; }
}