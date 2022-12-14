using EntityFrameworkCore.EncryptColumn.Attribute;

namespace MundoBalloonApi.infrastructure.Data.Models;

public class Orders : BaseEntity
{
    public int OrderId { get; init; }
    public string? UserId { get; init; }
    public int UserAddressesId { get; init; }
    public int UserProfileId { get; init; }
    public User? User { get; set; }
    public UserProfile? UserProfile { get; set; }
    public UserAddresses? UserAddresses { get; set; }
}