namespace MundoBalloonApi.business.DataObjects.Entities
{
    public class UserCart
    {
        public int UserId { get; set; }
        public string? Sku { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int? ProductVariantId { get; set; }
        public ProductVariant? Variant { get; set; }
    }
}