namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserAddress : BaseEntity
{
    public int UserAddressesId { get; set; }

    public string? UserId { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Zipcode { get; set; } = null!;

    public bool? IsBilling { get; set; }

    public bool IsShipping { get; set; }

    public virtual User? User { get; set; }
}