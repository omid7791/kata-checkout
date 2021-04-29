using System.Collections.Generic;
using System.Linq;
using Checkout.ItemPricingRules;
using Xunit;

namespace CheckoutUnitTests
{
    public class CheckoutUnitTests
    {
        private readonly List<IItemPricingRule> _pricingRules = new List<IItemPricingRule>
        {
            new ItemAPricingRule(),
            new ItemBPricingRule(),
            new ItemCPricingRule(),
            new ItemDPricingRule(),
        };

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        public void GivenAnItemIsScanned_WhenGettingTotalPrice_ShouldEqualUnitPrice(string item, int expectedUnitPrice)
        {
            // given
            var checkout = new Checkout.Checkout(_pricingRules);
            checkout.Scan(item);
            
            // when
            var actualTotalPrice = checkout.GetTotalPrice();
            
            // assert
            Assert.Equal(expectedUnitPrice, actualTotalPrice);
        }
        
        [Theory]
        [InlineData(new[] { "A", "B", "A", "C"}, 150)]
        [InlineData(new[] { "B", "A", "C"}, 100)]
        public void GivenMultipleItemsWithNoSpecialIsScanned_WhenGettingTotalPrice_ShouldEqualSumOfUnitPrices(
            string[] items, int expectedSumOfUnitPrices)
        {
            // given
            var checkout = new Checkout.Checkout(_pricingRules);
            items.ToList().ForEach(item => checkout.Scan(item));
            
            // when
            var actualTotalPrice = checkout.GetTotalPrice();
            
            // assert
            Assert.Equal(expectedSumOfUnitPrices, actualTotalPrice);
        }
        
        [Theory]
        [InlineData(new[] { "A", "A", "A", "C"}, 150)]
        [InlineData(new[] { "B", "A", "B"}, 95)]
        [InlineData(new[] { "A", "A", "A", "B", "B", "C"}, 195)]
        [InlineData(new[] { "A", "A", "A", "A", "A", "A"}, 260)]
        [InlineData(new[] { "B", "B", "B", "B"}, 90)]
        [InlineData(new[] { "B", "B", "B"}, 75)]
        [InlineData(new[] { "A", "A", "A", "A"}, 180)]
        public void GivenMultipleItemsWithSpecialPricingAreScanned_WhenGettingTotalPrice_ShouldEqualCorrectDiscountedPrice(
            string[] items, int expectedDiscountedPrice)
        {
            // given
            var checkout = new Checkout.Checkout(_pricingRules);
            items.ToList().ForEach(item => checkout.Scan(item));
            
            // when
            var actualTotalPrice = checkout.GetTotalPrice();
            
            // assert
            Assert.Equal(expectedDiscountedPrice, actualTotalPrice);
        }
    }
}