using AventStack.ExtentReports;
using Finonex.Utilities;
using OpenQA.Selenium;

namespace Finonex.Extensions
{
    class Update : Base
    {
        public static void Text(IWebDriver driver, IWebElement elem, string text, string elemName)
        {
            try
            {
                Wait.UntilElementIsClickable(driver, elem, 15, 250);
                elem.SendKeys(text);
                test.Log(Status.Pass, "Text: '" + text + ", is successfully updated on field: '" + elemName + "'");
                TestContext.Progress.WriteLine("text: '" + text + ", is successfully updated on the requested field");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Failed to update text on field: '" + elemName + "'", captureScreenShot(driver, fileName));
                TestContext.Progress.WriteLine(e.Message);
                Assert.Fail(e.StackTrace);
            }
        }
    }
}
