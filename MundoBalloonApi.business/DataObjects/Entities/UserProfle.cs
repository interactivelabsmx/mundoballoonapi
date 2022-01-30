namespace MundoBalloonApi.business.DataObjects.Entities;

public class UserProfile
{
    public int UserProfileId { get; set; }
    public int UserId { get; set; } = 0;
    public string ProcessorId { get; set; } = string.Empty;
    public string Picture { get; set; } = string.Empty;
}