using OpenQA.Selenium;

namespace Pages
{
    public abstract class BasePage(IWebDriver driver)
    {
        protected IWebDriver driver = driver;
    }
}