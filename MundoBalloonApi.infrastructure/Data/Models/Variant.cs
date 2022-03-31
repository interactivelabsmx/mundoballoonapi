namespace MundoBalloonApi.infrastructure.Data.Models;

public class Variant : BaseEntity
{
    public Variant()
    {
        VariantValues = new HashSet<VariantValue>();
        ProductVariantValues = new HashSet<ProductVariantValue>();
    }

    public int VariantId { get; set; }
    public string? Variant1 { get; set; }
    public string? VariantType { get; set; }

    public virtual ICollection<VariantValue> VariantValues { get; set; }
    public virtual ICollection<ProductVariantValue> ProductVariantValues { get; set; }
}