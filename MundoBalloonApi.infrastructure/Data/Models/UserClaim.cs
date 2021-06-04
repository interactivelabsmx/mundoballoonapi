
namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class UserClaim : BaseEntity
    {
        public int UserClaimsId { get; set; }
        public string? UserId { get; set; }
        public int ClaimId { get; set; }

        public virtual Claim? Claim { get; set; }
        public virtual User? User { get; set; }
    }
}
