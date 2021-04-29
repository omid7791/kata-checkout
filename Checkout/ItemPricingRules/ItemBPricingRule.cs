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
            var setsOfTwoCount = itemCount / 2;
            var remainder = itemCount % 2;
            
            if (setsOfTwoCount > 0)
                total += 45 * setsOfTwoCount;
            
            total += 30 * remainder;

            return total;
        }
    }
}