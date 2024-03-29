namespace MundoBalloonApi.business.DTOs.Entities;

public class Product : BaseDto
{
    public int? ProductId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ProductCategoryId { get; set; }
    public double Price { get; set; }

    public ProductCategory? Category { get; set; }
    public ICollection<ProductVariant>? Variants { get; set; }
}