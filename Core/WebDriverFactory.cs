using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Core
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(string browserName)
        {
            return browserName.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                _ => throw new ArgumentException($"Browser {browserName} is not supported.")
            };
        }
    }
}