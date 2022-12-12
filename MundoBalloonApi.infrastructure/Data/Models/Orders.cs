namespace MundoBalloonApi.infrastructure.Data.Models;

public class Orders : BaseEntity
{
    public int OrderId { get; set; } 
    public string UserId {get; set;} = string.Empty;
    public int OrderDetailsId { get; set; } 
    public User? User { get; set; }
    public OrderDetails? OrderDetails {get; set;}
}