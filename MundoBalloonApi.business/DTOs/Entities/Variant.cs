namespace MundoBalloonApi.business.DTOs.Entities;

public class Variant
{
    public int? VariantId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;

    public ICollection<VariantValue>? VariantValues { get; set; }
}