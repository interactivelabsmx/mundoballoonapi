namespace MundoBalloonApi.business.DataObjects.Entities;

public class UserOccasion
{
    public int UserOccasionId { get; set; }
    public int UserId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public DateTime? Date { get; set; }
    public string Details { get; set; } = string.Empty;

    public virtual ICollection<OccasionCart>? Carts { get; set; }
}