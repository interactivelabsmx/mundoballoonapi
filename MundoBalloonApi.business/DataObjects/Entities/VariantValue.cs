namespace MundoBalloonApi.business.DataObjects.Entities;

public class VariantValue
{
    public int? VariantValueId { get; set; } = 0;
    public int VariantId { get; set; }
    public string Value { get; set; } = string.Empty;

    public Variant? Variant { get; set; }
}