using HotChocolate;

namespace MundoBalloonApi.graphql.Common.Types
{
    public class ClientMutationBase
    {
        public ClientMutationBase(string clientMutationId)
        {
            ClientMutationId = clientMutationId;
        }

        [GraphQLDescription("Relay Client Mutation Id")]
        [GraphQLNonNullType]
        public string ClientMutationId { get; }
    }
}