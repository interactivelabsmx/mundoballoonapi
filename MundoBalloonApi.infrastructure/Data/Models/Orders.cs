namespace MundoBalloonApi.infrastructure.Data.Models;

public class Orders : BaseEntity
{
    public int OrderId { get; init; }
    public string? UserId { get; init; }
    public string? PaymentId { get; init; }
    public User? User { get; set; }

    public ICollection<OrderProductsDetails> OrdersOrderProductsDetails { get; set; } =
        new HashSet<OrderProductsDetails>();
}