namespace MundoBalloonApi.business.DataObjects.Entities;

public class User
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime? EmailVerified { get; set; }
    public string Image { get; set; } = string.Empty;

    public UserProfile? Profile { get; set; }
    public ICollection<UserAddrese>? Addreses { get; set; }
    public ICollection<UserCart>? Carts { get; set; }
    public ICollection<UserOccasion>? Occasions { get; set; }
    public ICollection<UserClaim>? UserClaims { get; set; }
}