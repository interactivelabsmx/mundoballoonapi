namespace MundoBalloonApi.business.DTOs.Entities;

public class ProductCategory : BaseDto
{
    public int? ProductCategoryId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}