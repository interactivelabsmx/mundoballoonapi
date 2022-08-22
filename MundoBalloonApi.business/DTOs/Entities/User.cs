namespace MundoBalloonApi.business.DTOs.Entities;

public class User
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;

    public ICollection<UserCart>? Carts { get; set; }
    public ICollection<UserEvent>? Events { get; set; }
    public ICollection<UserPaymentProfile>? PaymentProfiles { get; set; }
}