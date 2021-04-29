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
            var setsOfThreeCount = itemCount / 3;
            var remainder = itemCount % 3;
            
            if (setsOfThreeCount > 0)
                total += 130 * setsOfThreeCount;
            
            total += 50 * remainder;

            return total;
        }
    }
}