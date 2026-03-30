using OpenQA.Selenium;

namespace FinalTask.Pages
{
    public class AccountPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By MenuText = By.CssSelector(".menu_text");
        private readonly By MainHeading = By.CssSelector(".heading2");
        public string GetWelcomeMenuText() => driver.FindElement(MenuText).Text;
        public bool IsMainHeadingDisplayed() => driver.FindElement(MainHeading).Displayed;
    }
}