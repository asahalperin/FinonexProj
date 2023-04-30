using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Finonex.Extensions
{
    class Wait
    {

        public static void UntilElementIsClickable(IWebDriver driver, IWebElement elem, int seconds, int millis)
        {
            try
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(5);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(millis);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.Message = "Element: " + elem + " not found";
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(elem));
                TestContext.Progress.WriteLine("Element is appear");
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine(ex.Message);
                Assert.Fail("Element is not clickable. " + ex.StackTrace);
            }
        }

        public static void Implicit(IWebDriver driver, int seconds)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
                TestContext.Progress.WriteLine("Element is appear");
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine(ex.Message);
                Assert.Fail("Implicit wait fail. " + ex.StackTrace);
            }
        }
    }
}
