namespace MundoBalloonApi.infrastructure.Data.Models;

public class Product : BaseEntity
{
    public int ProductId { get; init; }
    public string ProductName { get; init; } = string.Empty;
    public string ProductDescription { get; init; } = string.Empty;
    public int ProductCategoryId { get; init; }
    public double Price { get; init; }

    public ProductCategory? ProductCategory { get; set; }
    public ICollection<ProductVariant> ProductVariants { get; } = new HashSet<ProductVariant>();
}