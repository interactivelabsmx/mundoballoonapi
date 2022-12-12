namespace MundoBalloonApi.infrastructure.Data.Models;

public class User : BaseEntity
{
    public string UserId { get; init; } = string.Empty;

    public ICollection<UserCart> UserCarts { get; } = new HashSet<UserCart>();
    public ICollection<UserEvent> UserEvents { get; } = new HashSet<UserEvent>();
    public ICollection<UserProfile> UserProfiles { get; } = new HashSet<UserProfile>();
    public ICollection<UserAddresses> UserAdrresses { get; } = new HashSet<UserAddresses>();
    public ICollection<Orders> Orders { get; } = new HashSet<Orders>();
    public ICollection<OrderDetails> OrderDetails { get; } = new HashSet<OrderDetails>();
    public ICollection<UserPaymentProfile>? UserPaymentProfiles { get; } = new HashSet<UserPaymentProfile>();
    public ICollection<ProductVariantReview>? ProductVariantReviews { get; } = new HashSet<ProductVariantReview>();
}