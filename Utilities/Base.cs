using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using Finonex.PageObjects;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace Finonex.Utilities
{
    public class Base
    {
        public IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;
        public static string fileName;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Website", "fortrade");

            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.fortrade.com/create-user/?tg=skip&tag1=break&G_GEO=9075129";
        }

        [SetUp]
        public void StartBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        [TearDown]
        public void AfterTest() { 
            HomePage homePage = new HomePage(driver);
            homePage.LogOut();
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {

                test.Fail("Test failed", captureScreenShot(driver, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);

            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Log(Status.Pass, "test passed!");
            }

            extent.Flush();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            extent.Flush();
            driver.Quit();
        }

        public static MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }
    }
}
