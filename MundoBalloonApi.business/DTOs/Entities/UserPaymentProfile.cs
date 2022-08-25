namespace MundoBalloonApi.business.DTOs.Entities;

public class UserPaymentProfile
{
    public int UserProfileId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string ProcessorId { get; set; } = string.Empty;

    public User? User { get; set; }
}