using OpenQA.Selenium;

namespace FinalTask.Pages
{
    public class MainPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By LoginRegisterLink = By.CssSelector("#customer_menu_top li a");
        private readonly By SpecialsLink = By.CssSelector("li[data-id='menu_specials'] a");
        public void GoToLoginRegister() => driver.FindElement(LoginRegisterLink).Click();
        public void GoToSpecials() => driver.FindElement(SpecialsLink).Click();
    }
}