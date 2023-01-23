using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users.Requests;

public class CreateOrderRequests
{
    public Orders? Order { get; set; }
    public IEnumerable<OrderProductsDetails>? OrderItems { get; set; }
}