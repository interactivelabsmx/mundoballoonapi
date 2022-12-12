namespace MundoBalloonApi.business.DTOs.Entities;

public class Orders 
{
    public int OrderId { get; set; } 
    public string UserId {get; set;} = string.Empty;
    public int OrderDetailsId { get; set; } 
}