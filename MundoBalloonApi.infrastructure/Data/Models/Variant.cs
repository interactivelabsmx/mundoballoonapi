using System.Collections.Generic;

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class Variant : BaseEntity
    {
        public Variant()
        {
            VariantValues = new HashSet<VariantValue>();
        }

        public int VariantId { get; set; }
        public string? Variant1 { get; set; }
        public string? VariantType { get; set; }

        public virtual ICollection<VariantValue> VariantValues { get; set; }
    }
}