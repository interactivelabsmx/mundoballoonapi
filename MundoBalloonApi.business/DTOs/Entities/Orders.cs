namespace MundoBalloonApi.business.DTOs.Entities;

public class Orders
{
    public int? OrderId { get; init; }

    public string UserId { get; init; } = string.Empty;
    public string PaymentId { get; init; } = string.Empty;

    public User? User { get; set; }
}