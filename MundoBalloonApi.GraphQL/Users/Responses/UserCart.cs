using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users.Responses;

public class UserCart
{
    public IEnumerable<UserCartProduct>? Products { get; set; }
    public double Subtotal { get; set; }
    public double Tax { get; set; }
    public double Total { get; set; }
}