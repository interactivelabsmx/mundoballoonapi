namespace MundoBalloonApi.business.DTOs.Entities;

public class OrderProductsDetails
{
    public int OrderDetailsProductsId { get; init; }
    public int OrderId { get; init; } 
    public int ProductVariantId { get; init; }
    public int amount { get; init; }
    public decimal price { get; init; }
    public ProductVariant? Variant { get; set; }
    public Orders? Order { get; set; }
    
}