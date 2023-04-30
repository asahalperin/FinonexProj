using AventStack.ExtentReports;
using Finonex.Utilities;
using OpenQA.Selenium;


namespace Finonex.Extensions
{
    class Pull : Base
    {
        public static string TextFromElement(IWebDriver driver, IWebElement elem, int seconds, string elemName)
        {
            string text = string.Empty;
            try
            {
                Wait.Implicit(driver, 20);
                text = elem.Text;
                test.Log(Status.Pass, "Element text: '" + text + "' pulled successfully from element: '" + elemName + "'");
                TestContext.Progress.WriteLine("Element text '" + text + "' pulled successfully");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, elemName + "Failed to pull text from element: '" + elemName + "'", captureScreenShot(driver, fileName));
                TestContext.Progress.WriteLine(e.Message);
                Assert.Fail(e.StackTrace);
            }
            return text;
        }
    }
}
