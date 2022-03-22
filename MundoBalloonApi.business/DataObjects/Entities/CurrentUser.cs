using System.Security.Claims;

namespace MundoBalloonApi.business.DataObjects.Entities;

public class CurrentUser
{
    public CurrentUser(string userId, IEnumerable<Claim> claims, List<string> flatClaims)
    {
        UserId = userId;
        Claims = claims;
        FlatClaims = flatClaims;
    }

    public string UserId { get; }
    public IEnumerable<Claim> Claims { get; }
    public List<string> FlatClaims { get; }
}