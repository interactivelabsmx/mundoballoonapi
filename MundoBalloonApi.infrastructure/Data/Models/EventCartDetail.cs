namespace MundoBalloonApi.infrastructure.Data.Models;

public class EventCartDetail : BaseEntity
{
    public int EventCartDetailId { get; set; }

    public int ProductVariantId { get; set; }

    public int UserEventId { get; set; }

    public decimal Quantity { get; set; }

    public virtual ProductVariant ProductVariant { get; set; } = null!;

    public virtual UserEvent UserEvent { get; set; } = null!;
}