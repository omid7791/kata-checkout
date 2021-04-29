using System.Collections.Generic;
using System.Linq;

namespace Checkout.ItemPricingRules
{
    public class ItemBPricingRule : IItemPricingRule
    {
        public int GetTotalPrice(List<string> items)
        {
            var total = 0;
            var itemCount = items.Count(item => item == "B");

            total += CalculateDiscountedPricing(itemCount);
            total += CalculateNoneDiscountedPricing(itemCount);

            return total;
        }
        
        private int CalculateNoneDiscountedPricing(int itemCount)
        {
            var remainder = itemCount % 2;

            return 30 * remainder;
        }

        private int CalculateDiscountedPricing(int itemCount)
        {
            var setsOfThreeCount = itemCount / 2;
            
            return 45 * setsOfThreeCount;
        }
    }
}