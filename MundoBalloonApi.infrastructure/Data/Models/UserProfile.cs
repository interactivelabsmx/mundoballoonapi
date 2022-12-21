using EntityFrameworkCore.EncryptColumn.Attribute;

namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserProfile : BaseEntity
{
    public int UserProfileId { get; init; }
    public string? UserId { get; init; } 
    public string? FirstName { get; init; }
    [EncryptColumn]
    public string? LastName { get; init; }
    [EncryptColumn]
    public int PhoneNumber { get; init; }
    [EncryptColumn]
    public User? User { get; set; }
    public ICollection<Orders> UserProfileOrder { get; set; } =
        new HashSet<Orders>();
}