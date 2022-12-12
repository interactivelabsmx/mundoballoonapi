namespace MundoBalloonApi.business.DTOs.Entities;

public class OrderDetails
{
    public int OrderDetailsId { get; set; } 
    public int ProductVariantId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int UserAddressesId { get; set; }
    public int UserProfileId { get; set; }
    public ProductVariant? Variant { get; set; }
}