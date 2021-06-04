using System;
using System.Collections.Generic;

namespace MundoBalloonApi.business.DTOs.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? EmailVerified { get; set; }
        public string? Image { get; set; }

        public UserProfile? Profile { get; set; }
        public ICollection<UserAddrese>? Addreses { get; set; }
        public ICollection<UserCart>? Carts { get; set; }
        public ICollection<UserOccasion>? Occasions { get; set; }
        public ICollection<UserClaim>? UserClaims { get; set; }
    }
}