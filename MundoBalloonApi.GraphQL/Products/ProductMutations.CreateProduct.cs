using HotChocolate;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Requests;
using MundoBalloonApi.graphql.Products.Requests;

namespace MundoBalloonApi.graphql.Products
{
    public partial class ProductMutations
    {
        public CreateProductPayload CreateProduct(
            CreateProductRequest input,
            [Service] IProductService productService)
        {
            
            var product = productService.CreateProduct(input);
            return new CreateProductPayload(product);
        }
    }
}