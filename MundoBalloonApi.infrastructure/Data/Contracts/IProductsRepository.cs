using System.Linq;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts
{
    public interface IProductsRepository
    {
        IQueryable<Product> GetProducts();
    }
}