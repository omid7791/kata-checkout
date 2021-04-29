using System.Collections.Generic;
using System.Linq;

namespace Checkout.ItemPricingRules
{
    public class ItemBPricingRule : IItemPricingRule
    {
        public int GetTotalPrice(List<string> items)
        {
            return 30 * items.Count(item => item == "B");
        }
    }
}