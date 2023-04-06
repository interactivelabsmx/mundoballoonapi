namespace MundoBalloonApi.infrastructure.Data.Models;

public class OrderProductsDetails : BaseEntity
{
    public int OrderDetailsProductsId { get; init; }
    public int OrderId { get; init; }
    public int ProductVariantId { get; init; }
    public double Quantity { get; init; }
    public double Price { get; init; }
    public Orders? Order { get; set; }
    public ProductVariant? ProductVariant { get; set; }
}