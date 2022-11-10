namespace MundoBalloonApi.business.DTOs.Entities;

public class ProductEntity : BaseDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ProductCategoryId { get; set; }
    public decimal Price { get; set; }
}