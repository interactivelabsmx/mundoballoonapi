namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserEventCartDetail : BaseEntity
{
    public int UserEventCartDetailId { get; init; }
    public int ProductVariantId { get; init; }
    public int UserEventId { get; init; }
    public double Quantity { get; init; }


    public ProductVariant? ProductVariant { get; set; }

    public UserEvent? UserEvent { get; set; }
}