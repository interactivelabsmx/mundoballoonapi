namespace MundoBalloonApi.business.DTOs.SiteService;

public class NavOption
{
    public int Order { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string? Href { get; set; }
    public NavCategory[]? Options { get; set; }
}