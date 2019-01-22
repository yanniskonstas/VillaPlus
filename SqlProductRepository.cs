using System;
using System.Collections.Generic;
using Domain;

namespace DataAccess
{
    public class SqlProductRepository : ProductRepository
    {
        public override IEnumerable<IProduct> GetProducts()
        { 
            throw new NotImplementedException();            
        }

        public override IEnumerable<Promotion> GetPromotions()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Promotion> GetPromotions(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }
    }
}
