namespace MundoBalloonApi.business.DataObjects.Entities;

public class Variant
{
    public int VariantId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;

    public ICollection<VariantValue>? VariantValues { get; set; }
}