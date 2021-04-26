namespace MundoBalloonApi.business.DTOs.Models
{
    public class OcassionCartDetail
    {
        public int OccasionCartId { get; set; }
        public string? Sku { get; set; }
        public int ProductVariantId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Label { get; set; }

        public ProductVariant? Variant { get; set; }
    }
}