namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class UserCart : BaseEntity
    {
        public int UserId { get; set; }
        public string? Sku { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int? ProductVariantId { get; set; }

        public virtual ProductVariant? ProductVariant { get; set; }
        public virtual ProductVariant? SkuNavigation { get; set; }
        public virtual User? User { get; set; }
    }
}