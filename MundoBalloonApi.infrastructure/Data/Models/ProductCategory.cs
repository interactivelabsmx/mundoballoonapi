namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductCategory : BaseEntity
{
    public int ProductCategoryId { get; set; }

    public string ProductCategoryName { get; set; } = null!;

    public string ProductCategoryDescription { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}