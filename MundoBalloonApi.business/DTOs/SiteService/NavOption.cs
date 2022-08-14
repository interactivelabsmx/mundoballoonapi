namespace MundoBalloonApi.business.DTOs.SiteService;

public class NavOption
{
    public int Order { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Href { get; init; }
    public NavCategory[]? Options { get; set; }
}