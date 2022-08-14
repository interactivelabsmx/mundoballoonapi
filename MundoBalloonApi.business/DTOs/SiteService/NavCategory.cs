namespace MundoBalloonApi.business.DTOs.SiteService;

public class NavCategory
{
    public int Order { get; set; }
    public string Name { get; init; } = string.Empty;
    public string Href { get; init; } = string.Empty;
    public string ImageSrc { get; init; } = string.Empty;
    public string ImageAlt { get; init; } = string.Empty;
}