namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserProfile : BaseEntity
{
    public int UserProfileId { get; init; }
    public string? UserId { get; init; } 
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int PhoneNumber { get; init; }
    public User? User { get; set; }
    public ICollection<Orders> UserProfileOrder { get; set; } =
        new HashSet<Orders>();
}