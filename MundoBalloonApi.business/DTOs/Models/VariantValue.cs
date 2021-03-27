namespace MundoBalloonApi.business.DTOs.Models
{
    public class VariantValue
    {
        public int VariantValueId { get; set; }
        public int VariantId { get; set; }
        public string? Value { get; set; }

        public Variant? Variant { get; set; }
    }
}