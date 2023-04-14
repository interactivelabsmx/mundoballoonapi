namespace MundoBalloonApi.business.DTOs.Entities;

public class UserEventCartDetail : BaseDto
{
    public int UserEventCartDetailId { get; set; }
    public int ProductVariantId { get; set; }
    public int UserEventId { get; init; }
    public double Quantity { get; set; }

    public ProductVariant? Variant { get; set; }
    public UserEvent? UserEvent { get; set; }
}