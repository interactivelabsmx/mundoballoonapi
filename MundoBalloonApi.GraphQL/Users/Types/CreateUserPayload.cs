using MundoBalloonApi.business.DTOs.Models;
using MundoBalloonApi.graphql.Common.Types;

namespace MundoBalloonApi.graphql.Users.Types
{
    public class CreateUserPayload : ClientMutationBase
    {
        public CreateUserPayload(User user) : base()
        {
            User = user;
        }

        public User User { get; }
    }
}