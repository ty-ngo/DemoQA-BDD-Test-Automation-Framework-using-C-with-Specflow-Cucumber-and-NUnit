using DemoQA.BDDTesting.Page;
using DemoQA.Services.Model.DataObject;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DemoQA.BDDTesting.StepDefinitions
{
    [Binding]
    public class RegisterStudentSteps
    {
        private FormPage _formPage;
        private readonly ScenarioContext _scenarioContext;
        private StudentDto studentInfo;

        public RegisterStudentSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _formPage = new FormPage();
        }

        [When(@"I fill all fields with valid info")]
        public void FillAllFieldsWithValidInfo(Table table)
        {
            studentInfo = table.CreateInstance<StudentDto>();
            _formPage.fillAllStudentInfo(studentInfo);
        }

        [When(@"I click on Submit button")]
        public void WhenIclickonSubmitbutton()
        {
            _formPage.clickSubmitButton();
        }

        [Then(@"thank you message and all student info is displayed correctly")]
        public void ThankYouMessageAndAllStudentInfoIsDisplayedCorrectly()
        {
            _formPage.checkThankYouMessage();
            _formPage.checkStudentInfo(studentInfo);
        }
    }
}