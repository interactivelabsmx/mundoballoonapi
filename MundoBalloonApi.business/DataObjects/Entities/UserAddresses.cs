﻿namespace MundoBalloonApi.business.DataObjects.Entities;

public class UserAddresses
{
    public int? UserAddressesId { get; set; } = 0;
    public int UserId { get; set; }
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Zipcode { get; set; } = string.Empty;
    public bool IsBilling { get; set; } = false;
    public bool IsShipping { get; set; } = false;
}