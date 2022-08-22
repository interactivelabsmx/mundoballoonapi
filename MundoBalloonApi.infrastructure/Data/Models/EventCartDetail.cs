namespace MundoBalloonApi.infrastructure.Data.Models;

public class EventCartDetail : BaseEntity
{
    public int EventCartId { get; init; }
    public string? Sku { get; init; }
    public int ProductVariantId { get; init; }
    public double Quantity { get; init; }
    public double Price { get; init; }
    public string? Label { get; init; }
    public int? user_event_id{get; init;}
    public string? created_at{get; init;}

    public string? update_at{get; init;}

    public string? isDeleted{get; init;}        

    public ProductVariant? ProductVariant { get; set; }
    public ProductVariant? SkuNavigation { get; set; }
    public UserEvent? UserEvent{get; set;}
}