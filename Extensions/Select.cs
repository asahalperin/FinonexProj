using AventStack.ExtentReports;
using Finonex.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Finonex.Extensions
{
    class Select : Base
    {
        public static void FromDropDown(IWebDriver driver, IWebElement elem, string text, string elemName)
        {
            try
            {
                Wait.UntilElementIsClickable(driver, elem, 20, 350);
                SelectElement dropDown = new SelectElement(elem);
                dropDown.SelectByText(text);
                test.Log(Status.Pass, "'" + text + "' selected successfully from drop down: '" + elemName + "'");
                TestContext.Progress.WriteLine("Selcted successfully");
            } 
            catch (Exception ex)
            {
                test.Log(Status.Fail, elemName + "Failed to select from drop down: '" + elemName + "'", captureScreenShot(driver, fileName));
                TestContext.Progress.WriteLine(ex.Message);
                Assert.Fail(ex.StackTrace);
            }
        }
    }
}
