using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CheckoutUnitTests
{
    public class CheckoutUnitTests
    {
        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        public void GivenAnItemIsScanned_WhenGettingTotalPrice_ShouldEqualUnitPrice(string item, int expectedUnitPrice)
        {
            // given
            var checkout = new Checkout.Checkout();
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
            var checkout = new Checkout.Checkout();
            items.ToList().ForEach(item => checkout.Scan(item));
            
            // when
            var actualTotalPrice = checkout.GetTotalPrice();
            
            // assert
            Assert.Equal(expectedSumOfUnitPrices, actualTotalPrice);
        }
    }
}