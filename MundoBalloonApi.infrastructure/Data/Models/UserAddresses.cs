using EntityFrameworkCore.EncryptColumn.Attribute;

namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserAddresses : BaseEntity
{
    public int UserAddressesId { get; init; }
    public string? UserId { get; init; } 

    public string? Address1 { get; init; }
    [EncryptColumn]
    public string? Address2 { get; init; }
    [EncryptColumn]
    public string? City { get; init; } 
    [EncryptColumn]
    public string? State { get; init; } 
    [EncryptColumn]
    public string? Country { get; init; } 
    [EncryptColumn]
    public string? Zipcode { get; init; } 
    [EncryptColumn]
    public int IsBilling { get; init; }
    public int IsShipping { get; init; }
    public User? User { get; set; }
}