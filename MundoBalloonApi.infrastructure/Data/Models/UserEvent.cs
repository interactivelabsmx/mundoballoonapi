namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserEvent : BaseEntity
{
    public int UserEventId { get; init; }
    public string? UserId { get; init; }
    public string? EventName { get; init; }
    public DateTime? EventDate { get; init; }
    public string? EventDetails { get; init; }

    public User? User { get; set; }
    public ICollection<EventCartDetail> EventCarts { get; set; } = new HashSet<EventCartDetail>();
}