namespace MundoBalloonApi.infrastructure.Data.Models;

public class Orders : BaseEntity
{
    public int OrderId { get; set; }
    public string? UserId { get; set; }
    public int? ProductVariantId { get; set; }
    public string? Sku { get; set; }
    public int UserAddressesId { get; set; }
    public int UserProfileId { get; set; }
    public ProductVariant? ProductVariant { get; set; }
    public User? User { get; set; }
    public UserAddresses? UserAddresses { get; set; }
    public UserProfile? UserProfile { get; set; }
}