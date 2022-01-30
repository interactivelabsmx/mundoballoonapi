namespace MundoBalloonApi.business.DataObjects.Entities;

public class Account
{
    public int Id { get; set; }
    public string CompoundId { get; set; } = string.Empty;
    public int UserId { get; set; }
    public string ProviderType { get; set; } = string.Empty;
    public string ProviderId { get; set; } = string.Empty;
    public string ProviderAccountId { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public DateTime? AccessTokenExpires { get; set; }
}