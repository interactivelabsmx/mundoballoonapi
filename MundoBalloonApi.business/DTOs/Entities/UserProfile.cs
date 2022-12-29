namespace MundoBalloonApi.business.DTOs.Entities;

public class UserProfile
{
    public int UserProfileId { get; init; }
    public string UserId { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public int PhoneNumber { get; init; }
}