namespace MundoBalloonApi.business.DataObjects.Entities;

public class ProductVariantMedium
{
    public int? ProductVariantMediaId { get; set; } = 0;
    public int ProductVariantId { get; set; }
    public string MediaType { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Quality { get; set; } = string.Empty;
    
    public virtual ProductVariant? ProductVariant { get; set; }
}