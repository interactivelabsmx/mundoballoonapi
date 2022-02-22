namespace MundoBalloonApi.business.DataObjects.Requests.Products;

public class UpdateProductRequest
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ProductCategoryId { get; set; }
    public double Price { get; set; }
}