namespace MundoBalloonApi.business.DataObjects.Entities
{
    public class ProductVariantMedium
    {
        public int ProductVariantMediaId { get; set; }
        public int ProductVariantId { get; set; }
        public string? MediaType { get; set; }
        public string? Url { get; set; }
        public string? Quality { get; set; }
    }
}