using MundoBalloonApi.graphql.Common.Types;

namespace MundoBalloonApi.graphql.Products.Types
{
    public class CreateProductInput : ClientMutationBase
    {
        public CreateProductInput(
            string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}