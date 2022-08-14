namespace MundoBalloonApi.business.DTOs.Entities;

public class UserPaymentProfile
{
    public int UserProfileId { get; set; }
    public int UserId { get; set; }
    public string ProcessorId { get; set; } = string.Empty;
}