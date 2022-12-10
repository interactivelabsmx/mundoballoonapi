namespace MundoBalloonApi.business.DTOs.Entities;

public class Orders 
{
    public int OrderId { get; set; } 
    public string UserId {get; set;} = string.Empty;
    public int ProductVariantId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int UserAddressesId { get; set; }
    public int UserProfileId { get; set; }
    public ProductVariant? Variant { get; set; }
}