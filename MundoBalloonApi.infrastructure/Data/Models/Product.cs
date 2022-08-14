namespace MundoBalloonApi.infrastructure.Data.Models;

public class Product : BaseEntity
{
    public int ProductId { get; init; }
    public string? ProductName { get; init; }
    public string? ProductDescription { get; init; }
    public int ProductCategoryId { get; init; }
    public double Price { get; init; }

    public ProductCategory? ProductCategory { get; } = new();
    public ICollection<ProductVariant> ProductVariants { get; } = new HashSet<ProductVariant>();
}