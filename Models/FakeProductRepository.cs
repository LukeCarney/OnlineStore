using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class FakeProductRepository /* : IProductRepository */
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product{ Name = "Jeans", Price = 50},
            new Product{ Name = "T-shirt", Price = 25},
            new Product{ Name = "Trainers", Price = 75}
        }.AsQueryable<Product>();
    }
}
