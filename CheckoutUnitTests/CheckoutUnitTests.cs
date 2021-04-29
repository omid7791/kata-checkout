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
    }
}