namespace MundoBalloonApi.infrastructure.Data.Models;

public class OrderDetails : BaseEntity
{
    public int OrderDetailsId { get; set; } 
    public int ProductVariantId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int UserAddressesId { get; set; }
    public int UserProfileId { get; set; }
    public ProductVariant? ProductVariant { get; set; }
    public UserAddresses? UserAddresses {get; set;}
    public UserProfile? UserProfile {get; set;}
    
}