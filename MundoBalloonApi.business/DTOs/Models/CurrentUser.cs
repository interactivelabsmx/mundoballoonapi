using System.Collections.Generic;
using System.Security.Claims;

namespace MundoBalloonApi.business.DTOs.Models
{
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
}