namespace MundoBalloonApi.infrastructure.Storage;

public class AzureStorageConfig
{
    public const string ConfigName = "AzureStorageConfig";
    public string AccountName { get; set; } = string.Empty;
    public string AccountKey { get; set; } = string.Empty;
    public string ImageContainer { get; set; } = string.Empty;
    public string ThumbnailContainer { get; set; } = string.Empty;
}