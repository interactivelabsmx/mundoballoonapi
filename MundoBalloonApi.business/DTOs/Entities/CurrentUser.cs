namespace MundoBalloonApi.business.DTOs.Entities;

public class CurrentUser
{
    public CurrentUser(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
}