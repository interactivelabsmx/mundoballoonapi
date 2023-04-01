namespace MundoBalloonApi.infrastructure.Data.Models;

public class User : BaseEntity
{
    public string UserId { get; init; } = string.Empty;
    public ICollection<Orders> Orders { get; set; } = new HashSet<Orders>();
    public ICollection<UserCartProduct> UserCarts { get; set; } = new HashSet<UserCartProduct>();
    public ICollection<UserEvent> UserEvents { get; set; } = new HashSet<UserEvent>();
    public ICollection<UserPaymentProfile> UserPaymentProfiles { get; set; } = new HashSet<UserPaymentProfile>();
    public ICollection<ProductVariantReview> ProductVariantReviews { get; set; } = new HashSet<ProductVariantReview>();
}