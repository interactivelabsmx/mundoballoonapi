namespace MundoBalloonApi.business.DTOs.Entities;

public class User
{
    public string UserId { get; set; } = string.Empty;

    public ICollection<UserCartProduct>? Carts { get; set; }
    public ICollection<UserEvent>? Events { get; set; }
    public ICollection<UserPaymentProfile>? PaymentProfiles { get; set; }
    public ICollection<ProductVariantReview>? Reviews { get; set; }
}