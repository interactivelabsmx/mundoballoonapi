namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductVariantMedium : BaseEntity
{
    public int ProductVariantMediaId { get; set; }

    public int ProductVariantId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string MediaType { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string? Quality { get; set; }

    public virtual ProductVariant ProductVariant { get; set; } = null!;
}