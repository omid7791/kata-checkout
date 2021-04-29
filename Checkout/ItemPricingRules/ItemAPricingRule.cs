using System.Collections.Generic;
using System.Linq;

namespace Checkout.ItemPricingRules
{
    public class ItemAPricingRule : IItemPricingRule
    {
        public int GetTotalPrice(List<string> items)
        {
            var total = 0;
            var itemCount = items.Count(item => item == "A");
            
            total += CalculateDiscountedPricing(itemCount);
            total += CalculateNoneDiscountedPricing(itemCount);
            
            return total;
        }

        private int CalculateNoneDiscountedPricing(int itemCount)
        {
            var remainder = itemCount % 3;

            return 50 * remainder;
        }

        private int CalculateDiscountedPricing(int itemCount)
        {
            var setsOfThreeCount = itemCount / 3;
            
            return 130 * setsOfThreeCount;
        }
    }
}