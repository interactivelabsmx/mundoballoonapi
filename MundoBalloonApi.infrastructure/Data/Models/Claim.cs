using System.Collections.Generic;

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class Claim : BaseEntity
    {
        public Claim()
        {
            UserClaims = new HashSet<UserClaim>();
        }

        public int ClaimId { get; set; }
        public string? Claim1 { get; set; }

        public virtual ICollection<UserClaim> UserClaims { get; set; }
    }
}