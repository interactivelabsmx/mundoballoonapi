namespace MundoBalloonApi.business.DataObjects.Entities;

public class CurrentUser
{
    public CurrentUser(string userId, IEnumerable<System.Security.Claims.Claim> claims, List<string> flatClaims)
    {
        UserId = userId;
        Claims = claims;
        FlatClaims = flatClaims;
    }

    public string UserId { get; }
    public IEnumerable<System.Security.Claims.Claim> Claims { get; }
    public List<string> FlatClaims { get; }
}