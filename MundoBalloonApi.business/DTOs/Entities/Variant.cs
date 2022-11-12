namespace MundoBalloonApi.business.DTOs.Entities;

public class Variant : BaseDto
{
    public int? VariantId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;

    public int? UiRegistryId { get; set; }

    public int VariantTypeId { get; set; }

    public UiRegistry? UiRegistry { get; set; }

    public virtual VariantsType? VariantType { get; set; } = null!;

    public ICollection<VariantValue>? VariantValues { get; set; }
}