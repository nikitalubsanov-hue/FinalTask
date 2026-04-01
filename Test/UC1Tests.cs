using FluentAssertions;
using Pages;
using Serilog;

namespace Test
{
    public class UC1Tests : BaseTest
    {
        public UC1Tests() : base() {}
        [Fact]
        public void UC1_CreateNewAccount_ShouldLoginSuccessfully()
        {
            // ARRANGE
            Log.Information("Starting UC-1");

            var mainPage = new MainPage(driver);
            mainPage.GoToLoginRegister();

            var loginPage = new AccountLoginPage(driver);
            loginPage.ClickContinueNewCustomer();

            var registerPage = new CreateAccountPage(driver);

            var uniqueSymbols = Guid.NewGuid().ToString()[..5];
            var uniqueLogin = $"user{uniqueSymbols}";
            var uniqueEmail = $"test{uniqueSymbols}@gmail.com";
            var firstName = "AppleSoup";
            var lastName = "Potato";
            var password = "Password1234";
            var expectedResult = $"Welcome back {firstName}";

            // ACT
            Log.Information("Filling form with login and other necessary fields");

            registerPage.FillRegistrationForm(firstName, lastName, uniqueEmail, uniqueLogin, password);
            registerPage.SubmitForm();

            // ASSERT
            var accountPage = new AccountPage(driver);
            var actualMenuText = accountPage.GetWelcomeMenuText();
            var isDisplayed = accountPage.IsMainHeadingDisplayed();

            isDisplayed.Should().BeTrue("The main heading 'My Account' should be visible on the page");
            actualMenuText.Should().Contain(expectedResult, "The header menu should welcome the user by their first name");

            Log.Information("UC-1 Finished successfully");
        }
    }
}