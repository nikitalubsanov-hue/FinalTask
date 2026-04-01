using FluentAssertions;
using Pages;
using Serilog;

namespace Test
{
    public class UC3Tests : BaseTest
    {
        public UC3Tests() : base() { }
        [Fact]
        public void UC3_SpecialOffers_AllProductsShouldHaveDiscount()
        {
            // ARRANGE
            Log.Information("Starting UC-3");

            var mainPage = new MainPage(driver);
            var specialsPage = new SpecialsPage(driver);

            // ACT
            Log.Information("Transition to the page with discounts");

            mainPage.GoToSpecials();
            bool hasDiscounts = specialsPage.AreAllProductsDiscounted();

            // ASSERT
            hasDiscounts.Should().BeTrue("All products on the Specials page must display both an old and a new price");

            Log.Information("UC-3 Finished successfully");
        }
    }
}