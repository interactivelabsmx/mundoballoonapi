namespace MundoBalloonApi.business.DataObjects.Entities;

public class UserClaim
{
    public int UserClaimsId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int ClaimId { get; set; }

    public Claim? Claim { get; set; }
}