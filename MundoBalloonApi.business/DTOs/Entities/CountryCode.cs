namespace MundoBalloonApi.business.DTOs.Entities;

public class CountryCode : BaseDto
{
    public string Fifa { get; set; } = String.Empty;
    
    public string Wmo { get; set; } = String.Empty;

    public string Dial { get; set; } = String.Empty;

    public string OfficialNameEs { get; set; } = String.Empty;
 
    public string OfficialNameEn { get; set; } = String.Empty;

    public bool Supported { get; set; }
}