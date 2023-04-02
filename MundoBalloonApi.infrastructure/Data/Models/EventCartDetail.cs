namespace MundoBalloonApi.infrastructure.Data.Models;

public class EventCartDetail : BaseEntity
{
    public int EventCartDetailId { get; init; }
    public int ProductVariantId { get; init; }
    public decimal Quantity { get; init; }
    public int? UserEventId { get; init; }

    public ProductVariant? ProductVariant { get; set; }

    public UserEvent? UserEvent { get; set; }
}