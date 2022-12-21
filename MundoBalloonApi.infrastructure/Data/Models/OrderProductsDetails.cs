using EntityFrameworkCore.EncryptColumn.Attribute;

namespace MundoBalloonApi.infrastructure.Data.Models;

public class OrderProductsDetails : BaseEntity
{
    public int OrderDetailsProductsId { get; init; }
    public int OrderId { get; init; }
    public int ProductVariantId { get; init; }
    public int amount { get; init; }
    public decimal price { get; init; }
    public Orders? Orders { get; set; }
    public ProductVariant? ProductVariant { get; set; }
}