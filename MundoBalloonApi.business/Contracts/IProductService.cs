using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.business.DataObjects.Requests;

namespace MundoBalloonApi.business.Contracts
{
    public interface IProductService
    {
        Product CreateProduct(CreateUserRequest createUserRequest);
    }
}