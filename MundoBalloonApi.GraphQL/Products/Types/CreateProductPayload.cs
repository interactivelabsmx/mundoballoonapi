using MundoBalloonApi.business.DTOs.Models;
using MundoBalloonApi.graphql.Common.Types;

namespace MundoBalloonApi.graphql.Products.Types
{
    public class CreateProductPayload : ClientMutationBase
    {
        public CreateProductPayload(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}