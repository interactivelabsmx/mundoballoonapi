namespace MundoBalloonApi.infrastructure.Data.Models;

public class CountryCode : BaseEntity
{
    public string Fifa { get; set; } = null!;

    public string Wmo { get; set; } = null!;

    public string? Dial { get; set; }

    public string? OfficialNameEs { get; set; }

    public string? OfficialNameEn { get; set; }

    public bool Supported { get; set; }
}