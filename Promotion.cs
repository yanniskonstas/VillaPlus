using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Promotion
    {   
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<IProduct> ApplicableProducts { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MinimumItemCount { get; set; }        
        public PromotionDiscountType DiscountType { get; set; }
        public decimal Discount { get; set; }        
    }

    public enum PromotionDiscountType
    {
        Amount, Percentage
    }
}
