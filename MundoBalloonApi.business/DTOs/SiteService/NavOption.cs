namespace MundoBalloonApi.business.DTOs.SiteService;

public class NavOption
{
    public string Name { get; set; } = String.Empty;
    public string? Href { get; set; }
    public NavCategory[]? Options  { get; set; }
}