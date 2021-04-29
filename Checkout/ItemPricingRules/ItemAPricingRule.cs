using System.Collections.Generic;
using System.Linq;

namespace Checkout.ItemPricingRules
{
    public class ItemAPricingRule : IItemPricingRule
    {
        public int GetTotalPrice(List<string> items)
        {
            return 50 * items.Count(item => item == "A");
        }
    }
}