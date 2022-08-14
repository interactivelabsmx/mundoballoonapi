namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductCategory : BaseEntity
{
    public int ProductCategoryId { get; init; }
    public string? ProductCategoryName { get; init; }
    public string? ProductCategoryDescription { get; init; }

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}