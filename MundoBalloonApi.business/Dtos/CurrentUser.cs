using System.Collections.Generic;
using System.Security.Claims;

namespace MundoBalloonApi.business.Dtos
{
        public class CurrentUser
        {
            public string UserId { get; }
            public IEnumerable<Claim> Claims { get; }
            
            public List<string> FlatClaims { get; }

            public CurrentUser(string userId, IEnumerable<Claim> claims, List<string> flatClaims)
            {
                UserId = userId;
                Claims = claims;
                FlatClaims = flatClaims;
            }
        }
}
