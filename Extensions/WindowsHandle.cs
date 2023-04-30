using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Finonex.Utilities;
using AventStack.ExtentReports;

namespace Finonex.Extensions
{
    class WindowsHandle : Base
    {
        public static void CloseAditioalWindow(IWebDriver driver, int seconds, string partialUrl)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                int num = driver.WindowHandles.Count();
                if (num > 1)
                {
                    string originalWindow = driver.CurrentWindowHandle;
                    foreach (string window in driver.WindowHandles)
                    {
                        if (originalWindow != window)
                        {
                            driver.SwitchTo().Window(window);
                            driver.Close();
                        }
                    }
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                }
                test.Log(Status.Pass, "New window with partial URL: '" + partialUrl + "' closed successfully");
                TestContext.Progress.WriteLine("The tab with url contains: " + partialUrl + " is not part of the test and closed successfully");
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine("There is no additioanl tab open. Test run will continue");
            }
        }
    }
}
