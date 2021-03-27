using System.Collections.Generic;

namespace MundoBalloonApi.business.DTOs.Models
{
    public class Variant
    {
        public int VariantId { get; set; }
        public string? Variant1 { get; set; }
        public string? Type { get; set; }

        public ICollection<VariantValue>? VariantValues { get; set; }
    }
}