namespace MundoBalloonApi.business.DTOs.Entities;

public class Orders
{
    public int OrderId { get; init; }
    public string UserId { get; init; } = string.Empty;
    public int UserAddressesId { get; init; }
    public int UserProfileId { get; init; }   
    public User? User { get; set; }
    public UserAddresses? Addresses { get; set; }
    public UserProfile? Profile { get; set; }
}