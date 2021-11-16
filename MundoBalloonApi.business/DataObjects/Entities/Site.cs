namespace MundoBalloonApi.business.DataObjects.Entities;

public class Site
{
    public IEnumerable<Product>? Products { get; set; }
    public IEnumerable<Product>? FeaturedProducts { get; set; }
    public IEnumerable<Product>? BestSellingProducts { get; set; }
    public IEnumerable<Product>? NewestProducts { get; set; }
}