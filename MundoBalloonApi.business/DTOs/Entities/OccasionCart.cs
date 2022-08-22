namespace MundoBalloonApi.business.DTOs.Entities;

public class EventCart
{
    public int? EventCartId { get; set; } = 0;
    public int UserEventId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string DropOffStage { get; set; } = string.Empty;

    public ICollection<EventCartDetail>? CartDetails { get; set; }
}