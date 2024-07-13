using Core.WebDriver;
using DemoQA.BDDTesting.Page;
using TechTalk.SpecFlow;
using DemoQA.BDDTesting.Hooks;
using DemoQA.Services.Model.DataObject;

namespace TMS.StepDefinitions
{
    [Binding]
    public class BaseSteps
    {
        private LoginPage _loginPage;
        public BaseSteps()
        {
            _loginPage = new LoginPage();
        }

        [Given(@"I go to DemoQA's register form page")]
        public void GoToFormPage()
        {
            DriverHelper.GoToUrl(Hook.FORM_URL);
        }

        [Given(@"I go to Book Store Page")]
        public void GoToBookStorePage()
        {
            DriverHelper.GoToUrl(Hook.BOOK_STORE_URL);
        }

        [When(@"I go to Profile Page")]
        [Given(@"I go to Profile Page")]
        public void GoToProfilePage()
        {
            DriverHelper.GoToUrl(Hook.PROFILE_URL);
        }

        [Given(@"I go to Login Page")]
        public void GoToLoginPage()
        {
            DriverHelper.GoToUrl(Hook.LOGIN_URL);
        }

        [Given(@"I login successfully with the account ""(.*)""")]
        public void LoginSuccessfullyWithAccount(string accountKey)
        {
            AccountDto account = Hook.AccountData[accountKey];
            _loginPage.login(account.userName, account.password);
        }
    }
}
