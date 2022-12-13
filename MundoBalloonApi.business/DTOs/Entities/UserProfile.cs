namespace MundoBalloonApi.business.DTOs.Entities;

public class UserProfile
{
    public int UserProfileId { get; set; } 
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int PhoneNumber { get; set; }
    public string UserId {get; set;} = string.Empty;
    
}