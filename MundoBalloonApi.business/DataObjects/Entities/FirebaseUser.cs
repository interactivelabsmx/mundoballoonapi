namespace MundoBalloonApi.business.DataObjects.Entities;

public class FirebaseUser : User
{
    public string? Email { get; set; } = string.Empty;
    public string? DisplayName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = string.Empty;

    public string?[]? Claims { get; set; }
}