namespace MundoBalloonApi.infrastructure.Data.Models;

public class CountryCode : BaseEntity
{
    public string Fifa { get; set; } = string.Empty;
    public string Wmo { get; set; } = string.Empty;
    public string Dial { get; set; } = string.Empty;
    public string Itu { get; set; } = string.Empty;
    public string Ioc { get; set; } = string.Empty;
    public string Ds { get; set; } = string.Empty;
    public string OfficialNameEs { get; set; } = string.Empty;
    public string OfficialNameEn { get; set; } = string.Empty;
    public string Capital { get; set; } = string.Empty;
    public string Continent { get; set; } = string.Empty;
    public string Languages { get; set; } = string.Empty;
    public int GeoNameId { get; set; }
    public bool Supported { get; set; }
}