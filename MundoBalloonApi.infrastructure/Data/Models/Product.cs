using System.Collections.Generic;

#nullable disable

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ProductVariants = new HashSet<ProductVariant>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal Price { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}