namespace MundoBalloonApi.business.DTOs.Entities;

public class UiRegistry : BaseDto
{
    public int UiRegistryId { get; init; }
    public string? ComponentId { get; init; }
    public bool Deprecated { get; init; } = false;
}