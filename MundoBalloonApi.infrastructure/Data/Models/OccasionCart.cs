namespace MundoBalloonApi.infrastructure.Data.Models;

public class OccasionCart : BaseEntity
{
    public int OccasionCartId { get; init; }
    public int UserOccasionId { get; init; }
    public string? OccasionCartDescription { get; init; }
    public string? Title { get; init; }
    public string? DropOffStage { get; init; }

    public UserOccasion? UserOccasion { get; set; }
    public ICollection<OccasionCartDetail> OccasionCartDetails { get; set; } = new HashSet<OccasionCartDetail>();
}