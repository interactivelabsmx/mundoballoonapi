namespace MundoBalloonApi.infrastructure.Data.Models;

public class VariantsType : BaseEntity
{
    public VariantsType()
    {
    }

    public VariantsType(string? variantType)
    {
        VariantType = variantType;
    }

    public int VariantTypeId { get; set; }

    public string? VariantType { get; set; }

    public virtual ICollection<Variant> Variants { get; } = new List<Variant>();
}