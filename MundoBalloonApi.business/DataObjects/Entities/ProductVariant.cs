namespace MundoBalloonApi.business.DataObjects.Entities;

public class ProductVariant
{
    public int ProductVariantId { get; set; }
    public string? Sku { get; set; }
    public int VariantValueId { get; set; }
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public double? Weight { get; set; }
    public bool? StoreOnly { get; set; }
    public bool? IsBundle { get; set; }

    public VariantValue? Variant { get; set; }
    public ICollection<ProductVariantMedium>? Media { get; set; }
}