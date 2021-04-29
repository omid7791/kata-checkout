using System.Collections.Generic;
using System.Linq;

namespace Checkout.ItemPricingRules
{
    public class ItemCPricingRule : IItemPricingRule
    {
        public int GetTotalPrice(List<string> items)
        {
            return 20 * items.Count(item => item == "C");
        }
    }
}