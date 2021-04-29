using System.Collections.Generic;
using System.Linq;

namespace Checkout.ItemPricingRules
{
    public class ItemAPricingRule : IItemPricingRule
    {
        public int GetTotalPrice(List<string> items)
        {
            var itemCount = items.Count(item => item == "A");
            var setsOfThreeCount = itemCount / 3;
            
            if (setsOfThreeCount > 0)
                return 130 * setsOfThreeCount;
            
            return 50 * itemCount;
        }
    }
}