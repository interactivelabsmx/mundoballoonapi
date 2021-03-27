using System.Collections.Generic;

namespace MundoBalloonApi.business.DTOs.Models
{
    public class Site
    {
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<Product>? FeaturedProducts { get; set; }
        public IEnumerable<Product>? BestSellingProducts { get; set; }
        public IEnumerable<Product>? NewestProducts { get; set; }
    }
}