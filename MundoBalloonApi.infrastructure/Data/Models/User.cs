namespace MundoBalloonApi.infrastructure.Data.Models;

public class User : BaseEntity
{
    public User()
    {
        UserAddressess = new HashSet<UserAddresses>();
        UserCarts = new HashSet<UserCart>();
        UserOccasions = new HashSet<UserOccasion>();
        UserPaymentProfiles = new HashSet<UserPaymentProfile>();
    }

    public int Id { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<UserAddresses> UserAddressess { get; set; }
    public virtual ICollection<UserCart> UserCarts { get; set; }
    public virtual ICollection<UserOccasion> UserOccasions { get; set; }
    public virtual ICollection<UserPaymentProfile>? UserPaymentProfiles { get; set; }
}