namespace MundoBalloonApi.business.DTOs.Entities;
using EntityFrameworkCore.EncryptColumn.Attribute;

public class UserProfile
{
    public int UserProfileId { get; set; } 
    public string FirstName { get; set; } = string.Empty;
    [EncryptColumn]
    public string LastName { get; set; } = string.Empty;
    [EncryptColumn]
    public int PhoneNumber { get; set; }
    [EncryptColumn]
    public string UserId {get; set;} = string.Empty;
    
}