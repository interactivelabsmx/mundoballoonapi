namespace MundoBalloonApi.business.DataObjects.Entities;

public class ProductVariant
{
    public int ProductVariantId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int VariantValueId { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public double Weight { get; set; } = 0;
    public bool StoreOnly { get; set; } = false;
    public bool IsBundle { get; set; } = false;

    public VariantValue? Variant { get; set; }
    public ICollection<ProductVariantMedium>? Media { get; set; }
}