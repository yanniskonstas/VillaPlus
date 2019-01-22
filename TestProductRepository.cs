using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace DataAccess
{
    public class TestProductRepository : ProductRepository
    {
        public override IEnumerable<IProduct> GetProducts()
        { 
            return new List<Product> {
                new Product { Id = 1, Name = "Product A", Price = 10},
                new Product { Id = 2, Name = "Product B", Price = 5},
                new Product { Id = 3, Name = "Product C", Price = 15},
            };
        }
        public override IEnumerable<Promotion> GetPromotions()
        {
            var testProducts = GetProducts().ToList();            
            return new List<Promotion> {
                new Promotion {
                    StartDate = new DateTime(2019, 1 ,1),
                    EndDate = new DateTime(2020, 12, 1),
                    MinimumItemCount = 0,
                    DiscountType = PromotionDiscountType.Percentage,
                    Discount = 50,
                    ApplicableProducts = new List<IProduct> {testProducts.First(p => p.Id == 1)}
                },
                new Promotion {
                    StartDate = new DateTime(2019, 1 ,1),
                    EndDate = new DateTime(2020, 12, 1),
                    MinimumItemCount = 2,
                    DiscountType = PromotionDiscountType.Percentage,
                    Discount = 100,
                    ApplicableProducts = new List<IProduct> {testProducts.First(p => p.Id == 3)}
                },
            };        
        }

        public override IEnumerable<Promotion> GetPromotions(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }
    }
}
