namespace MundoBalloonApi.business.DataObjects.Requests;

public class CreateProductRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ProductCategoryId { get; set; }
    public double Price { get; set; }
}