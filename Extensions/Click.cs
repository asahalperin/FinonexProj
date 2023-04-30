using AventStack.ExtentReports;
using Finonex.Utilities;
using OpenQA.Selenium;

namespace Finonex.Extensions
{
    class Click : Base
    {
        public static void Go(IWebDriver driver, IWebElement elem, string elemName)
        {
            try
            {
                Wait.UntilElementIsClickable(driver, elem, 20, 350);
                elem.Click();
                test.Log(Status.Pass, elemName + " Clicked successfully");
                TestContext.Progress.WriteLine("Clicked successfully");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, elemName + " Click is failed", captureScreenShot(driver, fileName));
                TestContext.Progress.WriteLine(e.Message);
                Assert.Fail(e.StackTrace);
            }
        }

        public static void Submit(IWebDriver driver, IWebElement elem, string elemName)
        {
            try
            {
                Wait.UntilElementIsClickable(driver, elem, 20, 350);
                elem.Submit();
                test.Log(Status.Pass, elemName + " Submitted successfully");
                TestContext.Progress.WriteLine("Submitted successfully");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, elemName + " Submit is failed", captureScreenShot(driver, fileName));
                TestContext.Progress.WriteLine(e.Message);
                Assert.Fail(e.StackTrace);
            }
        }
    }
}
