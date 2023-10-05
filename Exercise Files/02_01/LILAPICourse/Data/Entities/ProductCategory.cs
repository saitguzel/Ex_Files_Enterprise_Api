using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LILAPICourse.Data.Entities
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HashSet<Product> Products { get; set; }
    }
}
