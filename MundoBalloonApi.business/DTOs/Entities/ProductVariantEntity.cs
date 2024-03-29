namespace MundoBalloonApi.business.DTOs.Entities;

public class ProductVariantEntity
{
    public int ProductVariantId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
}