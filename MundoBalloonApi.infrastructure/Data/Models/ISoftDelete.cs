namespace MundoBalloonApi.infrastructure.Data.Models;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}