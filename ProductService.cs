using System;
using System.Collections.Generic;

namespace Domain
{
    public class ProductService
    {
        private readonly ProductRepository _repository;
        public IEnumerable<IProduct> Products { get; private set; }
        public IEnumerable<Promotion> Promotions { get; private set; }
        public IEnumerable<Promotion> PromotionsForProducts { get; private set; }
        public ProductService(ProductRepository repository)
        {
            if (repository == null)            
                throw new ArgumentNullException("Repository not found");
            _repository = repository;
        }

        public IEnumerable<IProduct> GetProducts()
        {
            Products = _repository.GetProducts();            
            return Products;
        }

        public IEnumerable<Promotion> GetPromotions()
        {
            Promotions = _repository.GetPromotions();            
            return Promotions;
        }
    }
}
