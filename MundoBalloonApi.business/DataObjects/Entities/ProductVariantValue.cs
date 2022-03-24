namespace MundoBalloonApi.business.DataObjects.Entities;

public class ProductVariantValue
{
    public int ProductVariantId { get; set; }
    public int VariantValueId { get; set; }

    public virtual ProductVariant? ProductVariant { get; set; }
    public virtual VariantValue? VariantValue { get; set; }
}
