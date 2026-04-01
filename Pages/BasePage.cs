using OpenQA.Selenium;

namespace FinalTask.Pages
{
    public abstract class BasePage(IWebDriver driver)
    {
        protected IWebDriver driver = driver;
    }
}