using AventStack.ExtentReports;
using Finonex.Utilities;
using OpenQA.Selenium;

namespace Finonex.Extensions
{
    class Navigate : Base
    {
        public static void ToUrl(IWebDriver driver, string url)
        {
            try
            {
                driver.Url = url;
                test.Log(Status.Pass, "Navigate successfully to url: '" + url + "'");
                TestContext.Progress.WriteLine("Navigate to url: " + url + " successfully");
            }
            catch(Exception ex)
            {
                test.Log(Status.Fail, " Click is failed", captureScreenShot(driver, fileName));
                TestContext.Progress.WriteLine(ex.Message);
                Assert.Fail("Navigate to url: " + url + " failed. " + ex.StackTrace);
            }
        }
    }
}
