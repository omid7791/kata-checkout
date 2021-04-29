using System.Collections.Generic;
using System.Linq;

namespace Checkout.ItemPricingRules
{
    public class ItemDPricingRule : IItemPricingRule
    {
        public int GetTotalPrice(List<string> items)
        {
            return 15 * items.Count(item => item == "D");
        }
    }
}