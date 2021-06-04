using System.Collections.Generic;

namespace MundoBalloonApi.business.DTOs.Models
{
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
}