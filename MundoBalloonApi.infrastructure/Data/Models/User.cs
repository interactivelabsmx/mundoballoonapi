namespace MundoBalloonApi.infrastructure.Data.Models;

public class User : BaseEntity
{
    public int Id { get; init; }

    public string UserId { get; init; } = string.Empty;

    public ICollection<UserCart> UserCarts { get; } = new HashSet<UserCart>();
    public ICollection<UserEvent> UserEvents { get; } = new HashSet<UserEvent>();
    public ICollection<UserPaymentProfile>? UserPaymentProfiles { get; } = new HashSet<UserPaymentProfile>();
}