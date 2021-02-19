using System.Collections.Generic;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.business.Dtos
{
    public class Site
    {
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<Product>? FeaturedProducts { get; set; }
        public IEnumerable<Product>? BestSellingProducts { get; set; }
        public IEnumerable<Product>? NewestProducts { get; set; }
    }
}