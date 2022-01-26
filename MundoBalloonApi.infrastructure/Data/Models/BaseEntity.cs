namespace MundoBalloonApi.infrastructure.Data.Models;

public class BaseEntity : ISoftDelete
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}