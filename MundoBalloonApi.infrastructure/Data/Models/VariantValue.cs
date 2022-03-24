namespace MundoBalloonApi.infrastructure.Data.Models;

public class VariantValue : BaseEntity
{
    public VariantValue()
    {
        ProductVariantValues = new HashSet<ProductVariantValue>();
    }

    public int VariantValueId { get; set; }
    public int VariantId { get; set; }
    public string? VariantValue1 { get; set; }

    public virtual Variant? Variant { get; set; }
    public virtual ICollection<ProductVariantValue> ProductVariantValues { get; set; }
}