using FinalTask.Core;
using OpenQA.Selenium;
using Serilog;

namespace FinalTask
{
    public abstract class BaseTest : IDisposable
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
        protected BaseTest()
        {
            driver = WebDriverFactory.CreateDriver(Constants.BrowserTypes.CHROME);
            //  or  driver = WebDriverFactory.CreateDriver(Constants.BrowserTypes.FIREFOX);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.TIMEOUT);
            driver.Navigate().GoToUrl(Constants.BASE_URL);
            driver.Manage().Window.Maximize();
        }
        public void Dispose()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}