using System.Collections.Generic;

namespace MundoBalloonApi.business.Dtos
{
        public class CurrentUser
        {
            public string UserId { get; }
            public List<string> Claims { get; }

            public CurrentUser(string userId, List<string> claims)
            {
                UserId = userId;
                Claims = claims;
            }
        }
}
