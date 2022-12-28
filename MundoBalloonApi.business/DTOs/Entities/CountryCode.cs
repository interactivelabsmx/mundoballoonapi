namespace MundoBalloonApi.business.DTOs.Entities;

public class CountryCode : BaseDto
{
    public string Fifa { get; set; } = string.Empty;

    public string Wmo { get; set; } = string.Empty;

    public string Dial { get; set; } = string.Empty;

    public string OfficialNameEs { get; set; } = string.Empty;

    public string OfficialNameEn { get; set; } = string.Empty;

    public bool Supported { get; set; }
}