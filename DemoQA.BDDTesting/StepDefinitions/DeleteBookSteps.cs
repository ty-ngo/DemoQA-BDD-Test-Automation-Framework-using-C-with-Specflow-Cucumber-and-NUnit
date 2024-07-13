using Core.API;
using Core.Configuration;
using Core.Utilities;
using DemoQA.BDDTesting.Constants;
using DemoQA.BDDTesting.Hooks;
using DemoQA.BDDTesting.Page;
using DemoQA.Services.Model.DataObject;
using DemoQA.Services.Services;
using FluentAssertions;
using Gherkin;
using TechTalk.SpecFlow;

namespace DemoQA.BDDTesting.StepDefinitions
{
    [Binding]
    public class DeleteBookSteps
    {
        protected static APIClient ApiClient;
        protected UserServices UserServices;
        protected BookServices _bookServices;
        private ProfilePage _profilePage;
        private readonly ScenarioContext _scenarioContext;
        private LoginPage _loginPage;

        public DeleteBookSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            _profilePage = new ProfilePage();
            _loginPage = new LoginPage();

            ApiClient = new APIClient(Hook.BASE_URL);

            UserServices = new UserServices(ApiClient);
            _bookServices = new BookServices(ApiClient);
        }

        [Given(@"there is a book named ""(.*)"" in ""(.*)"" collection")]
        public void ThereIsABookNamedInCollection(string bookName, string accountKey)
        {
            AccountDto account = Hook.AccountData[accountKey];
            string isbn = BookConstants.BookIsbn[bookName];
            string token = UserServices.GenerateToken(account.userName, account.password).Data.token.ToString();
            _bookServices.AddBooksToCollection(token, account.userId, [isbn]);
        }

        [When(@"I enter book name ""(.*)"" into search box")]
        public void EnterBookNameIntoSearchBox(string bookName)
        {
            _profilePage.SearchBooks(bookName);
        }

        [When(@"I delete the book ""(.*)""")]
        public void DeleteBook(string bookName)
        {
            _profilePage.deleteBook(bookName);
        }

        [Then(@"the book ""(.*)"" should disappear from my collection")]
        public void BookShouldDisappearFromMyCollection(string bookName)
        {
            _profilePage.checkBookExist(bookName).Should().BeFalse();
        }
    }
}