namespace MundoBalloonApi.infrastructure.Data.Models;

public class User : BaseEntity
{
    public string UserId { get; init; } = string.Empty;
    public ICollection<Orders> Orders { get; set; } = new HashSet<Orders>();
    public ICollection<UserCart> UserCarts { get; set; } = new HashSet<UserCart>();
    public ICollection<UserEvent> UserEvents { get; set; } = new HashSet<UserEvent>();
    public ICollection<UserAddresses> UserAdrresses { get; set; } = new HashSet<UserAddresses>();
    public ICollection<UserProfile> UserProfiles { get; set; } = new HashSet<UserProfile>();
    public ICollection<UserPaymentProfile> UserPaymentProfiles { get; set; } = new HashSet<UserPaymentProfile>();
    public ICollection<ProductVariantReview> ProductVariantReviews { get; set; } = new HashSet<ProductVariantReview>();
}