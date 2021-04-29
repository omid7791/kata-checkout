using System.Collections.Generic;

namespace Checkout.ItemPricingRules
{
    public interface IItemPricingRule
    { 
        int GetTotalPrice(List<string> items);
    }
}