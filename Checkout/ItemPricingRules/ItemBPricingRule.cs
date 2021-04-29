using System.Collections.Generic;
using System.Linq;

namespace Checkout.ItemPricingRules
{
    public class ItemBPricingRule : IItemPricingRule
    {
        public int GetTotalPrice(List<string> items)
        {
            var itemCount = items.Count(item => item == "B");
            var setsOfTwoCount = itemCount / 2;
            
            if (setsOfTwoCount > 0)
                return 45 * setsOfTwoCount;
            
            return 30 * itemCount;
        }
    }
}