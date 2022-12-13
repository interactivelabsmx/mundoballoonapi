using EntityFrameworkCore.EncryptColumn.Attribute;

namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserProfile : BaseEntity
{
    public int? UserProfileId { get; set; }
    public string? UserId { get; set; }
    public string? FirstName { get; set; }
    [EncryptColumn]
    public string? LastName { get; set; }
    [EncryptColumn]
    public int PhoneNumber { get; set; }
    [EncryptColumn]
    public User? User { get; set; }
    
}