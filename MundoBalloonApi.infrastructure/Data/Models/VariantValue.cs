namespace MundoBalloonApi.infrastructure.Data.Models;

public class VariantValue : BaseEntity
{
    public int VariantValueId { get; set; }

    public int VariantId { get; set; }

    public string? VariantValue1 { get; set; }

    public virtual ICollection<ProductVariantValue> ProductVariantValues { get; } = new List<ProductVariantValue>();

    public virtual Variant Variant { get; set; } = null!;
}