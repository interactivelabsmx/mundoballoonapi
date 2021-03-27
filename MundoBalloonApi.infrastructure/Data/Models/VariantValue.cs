using System.Collections.Generic;

#nullable disable

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class VariantValue : BaseEntity
    {
        public VariantValue()
        {
            ProductVariants = new HashSet<ProductVariant>();
        }

        public int VariantValueId { get; set; }
        public int VariantId { get; set; }
        public string VariantValue1 { get; set; }

        public virtual Variant Variant { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}