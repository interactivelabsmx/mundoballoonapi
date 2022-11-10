namespace MundoBalloonApi.business.DTOs.Entities;

public class ProductVariantValue : BaseDto
{
    public int ProductVariantId { get; set; }
    public int VariantId { get; set; }
    public int VariantValueId { get; set; }

    public ProductVariant? ProductVariant { get; set; }
    public Variant? Variant { get; set; }
    public VariantValue? VariantValue { get; set; }
}