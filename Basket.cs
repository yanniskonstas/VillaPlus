using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

namespace Domain
{
    public class Basket
    {
        private readonly ProductService _productService;
        public IEnumerable<IProduct> Products { get; set; }

        public Basket(ProductService productService) {
            _productService = productService;          
        }
        public decimal TotalAmount() {
            return Products.Sum(p => p.Price);
        }
        public decimal FinalAmount() {
            return TotalAmount() - DiscountAmount();
        }
        public decimal DiscountAmount() {            
            Func<PromotionDiscountType, decimal, decimal, decimal> GetDiscount = (t, d, p) => {
                switch (t) {
                    case PromotionDiscountType.Amount :
                        return Min(p, d);
                    case PromotionDiscountType.Percentage :
                        return Round((p / (decimal)100) * d, 2);
                    default:
                        return 0;
                }
            };
            decimal totDiscount = 0;
            var promotions = _productService.GetPromotions();
            foreach(var gp in Products.GroupBy(p => p.Id)){                
                decimal discount = 0;
                var promos = promotions.Where(p => p.StartDate <= DateTime.UtcNow
                                    && p.EndDate >= DateTime.UtcNow
                                    && p.ApplicableProducts.Any(ap => ap.Id == gp.Key)).ToList();
                promos.ForEach(p => {
                    if (p.MinimumItemCount > gp.Count()) return;
                    var disc = p.MinimumItemCount == 0 ?
                        GetDiscount(p.DiscountType, p.Discount, gp.First().Price) :
                        gp.Count()/p.MinimumItemCount * GetDiscount(p.DiscountType, p.Discount, gp.First().Price);
                    discount = disc > discount ? disc : discount;
                });
                totDiscount += discount;
            }            
            return totDiscount;
        }
    }
}
