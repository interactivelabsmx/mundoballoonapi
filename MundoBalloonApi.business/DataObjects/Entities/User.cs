﻿namespace MundoBalloonApi.business.DataObjects.Entities;

public class User
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;

    public ICollection<UserAddresses>? Addreses { get; set; }
    public ICollection<UserCart>? Carts { get; set; }
    public ICollection<UserOccasion>? Occasions { get; set; }
    public ICollection<UserPaymentProfile>? PaymentProfiles { get; set; }
}