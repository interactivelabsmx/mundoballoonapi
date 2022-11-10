namespace MundoBalloonApi.business.DTOs.Entities;

public class BaseDto
{
    public DateTime? CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public bool? IsDeleted { get; init; }
}