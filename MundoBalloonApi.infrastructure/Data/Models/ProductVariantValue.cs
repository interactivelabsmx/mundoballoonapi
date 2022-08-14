namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductVariantValue : BaseEntity
{
    public int ProductVariantId { get; init; }
    public int VariantId { get; init; }
    public int VariantValueId { get; init; }

    public ProductVariant? ProductVariant { get; set; }
    public Variant? Variant { get; set; }
    public VariantValue? VariantValue { get; set; }
}