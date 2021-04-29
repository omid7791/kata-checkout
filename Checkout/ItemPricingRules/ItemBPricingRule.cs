using System.Collections.Generic;
using System.Linq;

namespace Checkout.ItemPricingRules
{
    public class ItemBPricingRule : IItemPricingRule
    {
        public int GetTotalPrice(List<string> items)
        {
            var itemCount = items.Count(item => item == "B");
            
            if (itemCount == 2)
                return 45;
            
            return 30 * itemCount;
        }
    }
}