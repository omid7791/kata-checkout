using System.Collections.Generic;
using System.Linq;

namespace Checkout.ItemPricingRules
{
    public class ItemAPricingRule : IItemPricingRule
    {
        public int GetTotalPrice(List<string> items)
        {
            var itemCount = items.Count(item => item == "A");
            
            if (itemCount == 3)
                return 130;
            
            return 50 * itemCount;
        }
    }
}