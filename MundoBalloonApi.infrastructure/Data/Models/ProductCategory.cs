namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductCategory : BaseEntity
{
    public ProductCategory()
    {
        Products = new HashSet<Product>();
    }

    public int ProductCategoryId { get; set; }
    public string? ProductCategoryName { get; set; }
    public string? ProductCategoryDescription { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}