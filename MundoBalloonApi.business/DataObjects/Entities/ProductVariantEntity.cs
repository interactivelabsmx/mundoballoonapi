namespace MundoBalloonApi.business.DataObjects.Entities;

public class ProductVariantEntity
{
    public int ProductVariantId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int VariantValueId { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public double Weight { get; set; }
    public bool StoreOnly { get; set; }
    public bool IsBundle { get; set; }
}