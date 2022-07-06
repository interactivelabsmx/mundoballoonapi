namespace MundoBalloonApi.business.DTOs.Entities;

public class VariantValue
{
    public int? VariantValueId { get; set; } = 0;
    public int VariantId { get; set; }
    public string Value { get; set; } = string.Empty;

    public virtual ICollection<ProductVariantValue>? ProductVariantValues { get; set; }
}