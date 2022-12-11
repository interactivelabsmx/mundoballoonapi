namespace MundoBalloonApi.infrastructure.Data.Models;

public class Variant : BaseEntity
{
    public int VariantId { get; init; }
    public string? Variant1 { get; init; }
    public int? UiRegistryId { get; set; }
    public int? VariantTypeId { get; set; }

    public UiRegistry? UiRegistry { get; set; }
    public VariantsType? VariantsType { get; set; }

    public ICollection<VariantValue> VariantValues { get; set; } = new HashSet<VariantValue>();
    public ICollection<ProductVariantValue> ProductVariantValues { get; set; } = new HashSet<ProductVariantValue>();
}