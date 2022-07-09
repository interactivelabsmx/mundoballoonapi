namespace MundoBalloonApi.business.DTOs.SiteService;

public class NavCategory
{
    public int Order { get; set; } = 0;
    public string Name { get; set; } = String.Empty;
    public string Href { get; set; } = String.Empty;
    public string ImageSrc { get; set; } = String.Empty;
    public string ImageAlt { get; set; } = String.Empty;
}