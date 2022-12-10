namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserProfile : BaseEntity
{
    public int UserProfileId { get; set; }
    public string? UserId { get; set; }
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    public int PhoneNumber { get; set; }
    public User? User { get; set; }
    
}