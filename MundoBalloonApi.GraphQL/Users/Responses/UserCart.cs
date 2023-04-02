using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users.Responses;

public class UserCart
{
    public IEnumerable<UserCartProduct>? Products { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
}