using DemoQA.BDDTesting.Page;
using TechTalk.SpecFlow;

namespace DemoQA.BDDTesting.StepDefinitions
{
    [Binding]
    public class SearchBookSteps
    {
        private BookStorePage _bookStorePage;
        private readonly ScenarioContext _scenarioContext;

        public SearchBookSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _bookStorePage = new BookStorePage();
        }

        [When(@"I input the key word ""(.*)"" into search box")]
        public void InputKeyWordIntoSearchBox(string keyword)
        {
            _bookStorePage.SearchBooks(keyword);
        }


        [Then(@"all books matching with the key word ""(.*)"" is displayed")]
        public void AllBooksMatchingWithKeyWordIsDisplayed(string keyword)
        {
            _bookStorePage.checkSearchResult(keyword);
        }
    }
}