using EntityFrameworkCore.EncryptColumn.Attribute;

namespace MundoBalloonApi.business.DTOs.Entities;

public class UserAddresses
{
    public int UserAddressesId { get; init; }
    public string UserId { get; init; } = string.Empty;

    public string Address1 { get; init; } = string.Empty;
    [EncryptColumn]
    public string Address2 { get; init; } = string.Empty;
    [EncryptColumn]
    public string City { get; init; } = string.Empty;
    [EncryptColumn]
    public string State { get; init; } = string.Empty;
    [EncryptColumn]
    public string Country { get; init; } = string.Empty;
    [EncryptColumn]
    public string Zipcode { get; init; } = string.Empty;
    [EncryptColumn]
    public int IsBilling { get; init; }
    public int IsShipping { get; init; }
}