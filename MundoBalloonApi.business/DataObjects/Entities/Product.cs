namespace MundoBalloonApi.business.DataObjects.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ProductCategoryId { get; set; }
    public double Price { get; set; }

    public ProductCategory? Category { get; set; }
    public ICollection<ProductVariant>? Variants { get; set; }
}