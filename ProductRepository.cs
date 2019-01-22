using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class ProductRepository
    {
        public abstract IEnumerable<IProduct> GetProducts();
        public abstract IEnumerable<Promotion> GetPromotions();
        public abstract IEnumerable<Promotion> GetPromotions(IEnumerable<Product> products);
    }
}
