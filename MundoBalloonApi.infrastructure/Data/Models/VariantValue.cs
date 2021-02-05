#nullable disable

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class VariantValue : BaseEntity
    {
        public int VariantValueId { get; set; }
        public int VariantId { get; set; }
        public string VariantValue1 { get; set; }

        public virtual Variant Variant { get; set; }
        public virtual ProductVariant VariantValueNavigation { get; set; }
    }
}