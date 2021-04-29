using System.Collections.Generic;
using System.Linq;
using Checkout.ItemPricingRules;

namespace Checkout
{
    public class Checkout : ICheckout
    {
        private readonly List<IItemPricingRule> _itemPricingRules;
        private readonly List<string> _items = new List<string>();

        public Checkout(List<IItemPricingRule> itemPricingRules)
        {
            _itemPricingRules = itemPricingRules;
        }

        public void Scan(string item)
        {
            _items.Add(item);
        }

        public int GetTotalPrice()
        {
            var total = 0;
            total = _itemPricingRules.Select(rule => rule.GetTotalPrice(_items)).Sum();
            return total;
        }
    }
}