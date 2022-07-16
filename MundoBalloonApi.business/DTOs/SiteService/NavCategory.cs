namespace MundoBalloonApi.business.DTOs.SiteService;

public class NavCategory
{
    public int Order { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Href { get; set; } = string.Empty;
    public string ImageSrc { get; set; } = string.Empty;
    public string ImageAlt { get; set; } = string.Empty;
}