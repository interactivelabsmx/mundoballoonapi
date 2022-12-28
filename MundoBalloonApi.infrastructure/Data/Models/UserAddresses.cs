namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserAddresses : BaseEntity
{
    public int UserAddressesId { get; init; }
    public string? UserId { get; init; } 
    public string? Address1 { get; init; }
    public string? Address2 { get; init; }
    public string? City { get; init; } 
    public string? State { get; init; } 
    public string? Country { get; init; } 
    public string? Zipcode { get; init; } 
    public int IsBilling { get; init; }
    public int IsShipping { get; init; }
    public User? User { get; set; }
    public ICollection<Orders> OrdersUserAddresses { get; set; } =
        new HashSet<Orders>();
}