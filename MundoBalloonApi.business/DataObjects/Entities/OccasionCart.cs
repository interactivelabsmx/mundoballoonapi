namespace MundoBalloonApi.business.DataObjects.Entities;

public class OccasionCart
{
    public int OccasionCartId { get; set; }
    public int UserOccasionId { get; set; }
    public string? Description { get; set; }
    public string? Title { get; set; }
    public string? DropOffStage { get; set; }

    public ICollection<OcassionCartDetail>? CartDetails { get; set; }
}