namespace MundoBalloonApi.infrastructure.Data.Models;

public partial class CountryCode : BaseEntity
{
    public string Fifa { get; set; }
    public string Wmo { get; set; }
    public string Dial { get; set; }
    public string Itu { get; set; }
    public string Ioc { get; set; }
    public string Ds { get; set; }
    public string OfficialNameEs { get; set; }
    public string OfficialNameEn { get; set; }
    public string Capital { get; set; }
    public string Continent { get; set; }
    public string Languages { get; set; }
    public int? GeonameId { get; set; }
    public bool? Supported { get; set; }
}

