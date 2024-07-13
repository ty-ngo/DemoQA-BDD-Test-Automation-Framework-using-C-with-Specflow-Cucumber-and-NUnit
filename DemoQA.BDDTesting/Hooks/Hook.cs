using Core.API;
using Core.Configuration;
using Core.Reports;
using Core.ShareData;
using Core.Utilities;
using Core.WebDriver;
using DemoQA.BDDTesting.Constants;
using DemoQA.Services.Model.DataObject;
using DemoQA.Services.Services;
using TechTalk.SpecFlow;

namespace DemoQA.BDDTesting.Hooks
{
    [Binding]
    public class Hook
    {

        private ScenarioContext _scenarioContext;
        const string AppSettingPath = "Configurations/appsettings.json";

        public static string BROWSER = ConfigurationHelper.GetConfiguration()["browser"];
        public static string BASE_URL = ConfigurationHelper.GetConfiguration()["application:base_url"];
        public static string FORM_URL = ConfigurationHelper.GetConfiguration()["application:form_url"];
        public static string BOOK_STORE_URL = ConfigurationHelper.GetConfiguration()["application:book_store_url"];
        public static string PROFILE_URL = ConfigurationHelper.GetConfiguration()["application:profile_url"];
        public static string LOGIN_URL = ConfigurationHelper.GetConfiguration()["application:login_url"];
        public static int IMPLICIT_WAIT_SECONDS = int.Parse(ConfigurationHelper.GetConfiguration()["implicit.wait.seconds"]);
        public static int PAGE_LOAD_SECONDS = int.Parse(ConfigurationHelper.GetConfiguration()["page.load.seconds"]);

        public static Dictionary<string, AccountDto> AccountData = JsonUtils.ReadDictionaryJson<AccountDto>(FilePathConstants.AccountPath);


        public Hook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;


            // ExtentTestManager.CreateParentTest(TestContext.CurrentContext.Test.ClassName);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun");
            var config = ConfigurationHelper.ReadConfiguration(AppSettingPath);
            DataStorage.InitData();
            ExtentReportManager.AddSystemInfo("Environment", config["environment"]);
            ExtentReportManager.AddSystemInfo("Browser", config["browser"]);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext){
            ExtentTestManager.CreateParentTest(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario");
            var browser = ConfigurationHelper.GetConfiguration()["browser"];

            DriverManager.InitDriver(BROWSER);
            DriverManager.WebDriver.Manage().Window.Maximize();
            DriverManager.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLICIT_WAIT_SECONDS);
            DriverManager.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PAGE_LOAD_SECONDS);
            
            ExtentTestManager.CreateScenarioContext(_scenarioContext);
        }

        [AfterStep]
        public static void AfterStep(){
            ExtentTestManager.UpdateStepContext();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After Scenario");
            ExtentTestManager.UpdateScenarioContext();
            ReportLog.Info("Close WebDriver");
            DriverManager.CloseDriver();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("AfterTestRun");
            ExtentReportManager.GenerateReport();
        }
    }
}
