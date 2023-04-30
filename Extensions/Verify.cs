
using AventStack.ExtentReports;
using Finonex.Utilities;
using OpenQA.Selenium;

namespace Finonex.Extensions
{
    class Verify : Base
    {
        public static void TextContains(IWebDriver driver, string actual, string expected, string containAt)
        {
            try 
            {
                Assert.That(actual.Contains(expected));
                test.Log(Status.Pass, "Actual text: '" + actual + "' contains " + containAt + " expected text: '" + expected + "'");
                TestContext.Progress.WriteLine("Actual text: '" + actual + "' contains " + containAt + " expected text: '" + expected + "'");
            } 
            catch (Exception ex) {
                test.Log(Status.Fail, "Actual text: '" + actual + "' does not contains" + containAt + "expected text: '" + expected, captureScreenShot(driver, fileName));
                TestContext.Progress.WriteLine("Actual text: '" + actual + "' does not contains" + containAt + "expected text: '" + expected + "'." + ex.Message);
                Assert.Fail(ex.StackTrace);
            }
        }

        public static void TextEquals(IWebDriver driver, string actual, string expected, string equalAt)
        {
            try
            {
                Assert.That(actual.Equals(expected));
                test.Log(Status.Pass, "Actual text: '" + actual + "' equal " + equalAt + " expected text: '" + expected + "'");
                TestContext.Progress.WriteLine("Passed! Actual text: '" + actual + "' is equal to the expected text: '" + expected + "'");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, "Actual text: '" + actual + "' does not equal" + equalAt + "expected text: '" + expected, captureScreenShot(driver, fileName));
                TestContext.Progress.WriteLine("Failed! Actual text: '" + actual + "' does not equal to the expected text: '" + expected + "'." + ex.Message);
                Assert.Fail(ex.StackTrace);
            }
        }
    }
}
