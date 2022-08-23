namespace MundoBalloonApi.business.DTOs.Entities;

public class UserEvent
{
    public int? UserEventId { get; set; } = 0;
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? Date { get; set; }
    public string Details { get; set; } = string.Empty;
    public User? User { get; set; }
    public ICollection<EventCartDetail>? Carts { get; set; }
}