using System;
using System.Collections.Generic;

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            UserAddreses = new HashSet<UserAddrese>();
            UserCarts = new HashSet<UserCart>();
            UserOccasions = new HashSet<UserOccasion>();
        }

        public int Id { get; set; }

        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? EmailVerified { get; set; }
        public string? Image { get; set; }

        public virtual UserProfile? UserProfile { get; set; }
        public virtual ICollection<UserAddrese> UserAddreses { get; set; }
        public virtual ICollection<UserCart> UserCarts { get; set; }
        public virtual ICollection<UserOccasion> UserOccasions { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
    }
}