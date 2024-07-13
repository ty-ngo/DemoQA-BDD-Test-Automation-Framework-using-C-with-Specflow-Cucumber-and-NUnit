using DemoQA.BDDTesting.Page;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DemoQA.BDDTesting.StepDefinitions
{
    [Binding]
    public class AddBookSteps
    {
        private BookStorePage _bookStorePage;
        private LoginPage _loginPage;
        private ProfilePage _profilePage;
        private readonly ScenarioContext _scenarioContext;

        public AddBookSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _bookStorePage = new BookStorePage();
            _loginPage = new LoginPage();
            _profilePage = new ProfilePage();
        }

        [When(@"I click on the title of the book ""(.*)""")]
        public void ClickOnTitleOfBook(string bookName)
        {
            _bookStorePage.GoToBookDetailPage(bookName);
        }

        [When(@"I click on Add to Collection button")]
        public void ClickoOnAddToCollectionButton()
        {
            //TO DO: click on the button 'Add to Collection'
        }

        [Then(@"the book ""(.*)"" should appear in my collection")]
        public void BookShouldAppearInMyCollection(string bookName)
        {
            _profilePage.checkBookExist(bookName).Should().BeTrue();
        }
    }
}