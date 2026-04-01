/*using FluentAssertions;
using FinalTask.Pages;
using Serilog;

namespace FinalTask
{
    public class UC2Tests : BaseTest
    {
        public UC2Tests() : base() {}
        [Theory]
        [InlineData("", "Login name must be alphanumeric only and between 5 and 64 characters!")]
        [InlineData("ab", "Login name must be alphanumeric only and between 5 and 64 characters!")]
        [InlineData("thisloginnameiswaytoolongtobeacceptedbythesystem12345678901234567", "Login name must be alphanumeric only and between 5 and 64 characters!")]
        public void UC2_RegistrationForm_InvalidLoginName_ShouldShowError(string invalidLogin, string expectedErrorMsg)
        {
            // ARRANGE
            Log.Information("Starting UC-2");

            var mainPage = new MainPage(driver);
            mainPage.GoToLoginRegister();
            var loginPage = new AccountLoginPage(driver);
            loginPage.ClickContinueNewCustomer();
            var registerPage = new CreateAccountPage(driver);

            // ACT
            Log.Information("Filling form with invalidlogin only");

            registerPage.FillLoginNameOnly(invalidLogin);
            registerPage.SubmitForm();

            // ASSERT
            var actualError = registerPage.GetLoginNameErrorMessage();
            actualError.Should().Be(expectedErrorMsg, $"Error message for login '{invalidLogin}' should match the strict validation requirements");

            Log.Information("UC-2 Finished successfully");
        }
    }
}*/