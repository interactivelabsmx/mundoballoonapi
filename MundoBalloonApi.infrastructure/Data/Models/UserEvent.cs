namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserEvent : BaseEntity
{
    public int UserEventId { get; set; }

    public string? UserId { get; set; }

    public string EventName { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public string? EventDetails { get; set; }

    public virtual ICollection<EventCartDetail> EventCartDetails { get; } = new List<EventCartDetail>();

    public virtual User? User { get; set; }
}