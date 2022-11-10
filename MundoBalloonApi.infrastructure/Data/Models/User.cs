namespace MundoBalloonApi.infrastructure.Data.Models;

public class User : BaseEntity
{
    public string UserId { get; set; } = null!;

    public virtual ICollection<ProductVariantReview> ProductVariantReviews { get; } = new List<ProductVariantReview>();

    public virtual ICollection<UserAddress> UserAddresses { get; } = new List<UserAddress>();

    public virtual ICollection<UserCart> UserCarts { get; } = new List<UserCart>();

    public virtual ICollection<UserEvent> UserEvents { get; } = new List<UserEvent>();

    public virtual ICollection<UserPaymentProfile> UserPaymentProfiles { get; } = new List<UserPaymentProfile>();
}