namespace MundoBalloonApi.infrastructure.Data.Models;

public class UiRegistry : BaseEntity
{
    public int UiRegistryId { get; set; }
    public string ComponentId { get; set; } = null!;
    public bool Deprecated { get; set; }

    public ICollection<Variant> Variants { get; set; } = new HashSet<Variant>();
}