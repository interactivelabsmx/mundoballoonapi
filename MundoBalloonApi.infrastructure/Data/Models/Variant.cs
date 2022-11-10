namespace MundoBalloonApi.infrastructure.Data.Models;

public class Variant : BaseEntity
{
    public int VariantId { get; set; }

    public string? Variant1 { get; set; }

    public int VariantTypeId { get; set; }

    public int? UiRegistryId { get; set; }

    public virtual ICollection<ProductVariantValue> ProductVariantValues { get; } = new List<ProductVariantValue>();

    public virtual UiRegistry? UiRegistry { get; set; }

    public virtual VariantsType VariantType { get; set; } = null!;

    public virtual ICollection<VariantValue> VariantValues { get; } = new List<VariantValue>();
}