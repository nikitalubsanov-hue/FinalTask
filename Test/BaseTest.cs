using Core;
using OpenQA.Selenium;
using Serilog;
using System.Buffers.Text;

namespace Test
{
    public class BaseTest : IDisposable
    {
        protected readonly IWebDriver driver;
        static BaseTest()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("logs/test_execution.log", rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("RUNNING TESTS");
        }
        public BaseTest()
        {
            string browser = ConfigReader.Browser!;
            string baseUrl = ConfigReader.BaseUrl!;
            
            Log.Information($"Initializing browser: {browser.ToUpper()}");
            Log.Information($"Navigating to URL: {baseUrl}");

            driver = WebDriverFactory.CreateDriver(browser);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.TIMEOUT);
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
        }
        public void Dispose()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}