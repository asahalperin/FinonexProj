using Finonex.Extensions;
using Finonex.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Finonex.PageObjects
{
    public class AccountPage
    {
        private IWebDriver driver;

        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToDisplay()
        {
            Wait.UntilElementIsClickable(driver, RealAccountId, 20, 350);
        }

        public void PullRealAccountId()
        {
            User.RealAccountText(driver, RealAccountId, 20, "Real account ID text");
        }

        [FindsBy(How = How.XPath, Using = "(//span[text() = 'Real Account']/parent::td/following-sibling::td[@class='ascUserDataText'])[3]")]
        private IWebElement RealAccountId;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'ascAreaItem')]/div[@class='ascText']/div[contains(@class, 'LcContent')]")]
        private IWebElement DearUserText;

        public IWebElement GetRealAccountId()
        {
            return RealAccountId;
        }

        public IWebElement getDearUserText()
        {
            return DearUserText;
        }
    }
}
