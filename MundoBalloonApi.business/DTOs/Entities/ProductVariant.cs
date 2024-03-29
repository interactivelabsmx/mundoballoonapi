namespace MundoBalloonApi.business.DTOs.Entities;

public class ProductVariant
{
    public int? ProductVariantId { get; set; } = 0;
    public string Sku { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }

    public ICollection<ProductVariantMedium>? Media { get; set; }
    public ICollection<ProductVariantValue>? VariantValues { get; set; }
    public ICollection<ProductVariantReview>? Reviews { get; set; }
}