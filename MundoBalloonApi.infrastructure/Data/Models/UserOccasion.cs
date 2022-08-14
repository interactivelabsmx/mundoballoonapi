namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserOccasion : BaseEntity
{
    public int UserOccasionId { get; init; }
    public int? UserId { get; init; }
    public string? OccasionName { get; init; }
    public DateTime? OccasionDate { get; init; }
    public string? OccasionDetails { get; init; }

    public User? User { get; set; }
    public ICollection<OccasionCart> OccasionCarts { get; set; } = new HashSet<OccasionCart>();
}