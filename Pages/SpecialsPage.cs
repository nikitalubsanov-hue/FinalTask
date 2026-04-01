using OpenQA.Selenium;

namespace FinalTask.Pages
{
    public class SpecialsPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By ProductContainers = By.CssSelector(".grid .thumbnail");
        private readonly By OldPrice = By.CssSelector(".priceold");
        private readonly By NewPrice = By.CssSelector(".pricenew");
        public bool AreAllProductsDiscounted()
        {
            var products = driver.FindElements(ProductContainers);

            if (products.Count == 0)
            {
            return false;
            }

            foreach (var product in products)
            {
                bool hasOldPrice = product.FindElements(OldPrice).Count > 0;
                bool hasNewPrice = product.FindElements(NewPrice).Count > 0;

                if (!hasOldPrice || !hasNewPrice)
                {
                    return false;
                }
            }

            return true;
        }
    }
}