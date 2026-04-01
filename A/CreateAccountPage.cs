using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class CreateAccountPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By FirstNameInput = By.CssSelector("input[name='firstname']");
        private readonly By LastNameInput = By.CssSelector("input[name='lastname']");
        private readonly By EmailInput = By.CssSelector("input[name='email']");
        private readonly By Address1Input = By.CssSelector("input[name='address_1']");
        private readonly By CityInput = By.CssSelector("input[name='city']");
        private readonly By CountrySelect = By.CssSelector("select[name='country_id']");
        private readonly By ZoneSelect = By.CssSelector("select[name='zone_id']");
        private readonly By PostcodeInput = By.CssSelector("input[name='postcode']");
        private readonly By LoginNameInput = By.CssSelector("input[name='loginname']");
        private readonly By PasswordInput = By.CssSelector("input[name='password']");
        private readonly By ConfirmPasswordInput = By.CssSelector("input[name='confirm']");
        private readonly By NewsletterNoRadio = By.CssSelector("#AccountFrm_newsletter0");
        private readonly By PrivacyPolicyCheckbox = By.CssSelector("#AccountFrm_agree");
        private readonly By ContinueButton = By.CssSelector(".btn-orange");
        private readonly By LoginNameErrorLabel = By.CssSelector(".form-group:has(#AccountFrm_loginname) .help-block");

        public void FillRegistrationForm(string first, string last, string email, string login, string password)
        {
            driver.FindElement(FirstNameInput).SendKeys(first);
            driver.FindElement(LastNameInput).SendKeys(last);
            driver.FindElement(EmailInput).SendKeys(email);
            driver.FindElement(Address1Input).SendKeys(Constants.LocatorValue.STREET);
            driver.FindElement(CityInput).SendKeys(Constants.LocatorValue.CITY);

            var selectCountry = new SelectElement(driver.FindElement(CountrySelect));
            selectCountry.SelectByValue(Constants.LocatorValue.ZONE_ID);

            var selectZone = new SelectElement(driver.FindElement(ZoneSelect));
            selectZone.SelectByValue(Constants.LocatorValue.COUNTRY_ID);

            driver.FindElement(PostcodeInput).SendKeys(Constants.LocatorValue.POST);
            driver.FindElement(LoginNameInput).SendKeys(login);
            driver.FindElement(PasswordInput).SendKeys(password);
            driver.FindElement(ConfirmPasswordInput).SendKeys(password);
            driver.FindElement(NewsletterNoRadio).Click();
            driver.FindElement(PrivacyPolicyCheckbox).Click();
        }
        public void FillLoginNameOnly(string login)
        {
            var loginField = driver.FindElement(LoginNameInput);
            loginField.Clear();
            loginField.SendKeys(login);
        }
        public void SubmitForm() => driver.FindElement(ContinueButton).Click();
        public string GetLoginNameErrorMessage() => driver.FindElement(LoginNameErrorLabel).Text;
    }
}