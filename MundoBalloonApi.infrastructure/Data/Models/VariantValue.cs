namespace MundoBalloonApi.infrastructure.Data.Models;

public class VariantValue : BaseEntity
{
    public int VariantValueId { get; init; }
    public int VariantId { get; init; }
    public string? VariantValue1 { get; init; }

    public Variant? Variant { get; set; }
    public ICollection<ProductVariantValue> ProductVariantValues { get; set; } = new HashSet<ProductVariantValue>();
}