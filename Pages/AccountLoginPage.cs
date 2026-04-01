using OpenQA.Selenium;

namespace Pages
{
    public class AccountLoginPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By ContinueButton = By.CssSelector("button.btn-orange[title='Continue']");

        public void ClickContinueNewCustomer() => driver.FindElement(ContinueButton).Click();
    }
}