using Finonex.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Finonex.PageObjects
{
    public class PaymentPage
    {
        private IWebDriver driver;

        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToDisplay()
        {
            Wait.UntilElementIsClickable(driver, AmountField, 20, 350);
        }

        public AccountPage NavigateToAccount(string url)
        {
            Navigate.ToUrl(driver, url);
            return new AccountPage(driver);
        }

        [FindsBy(How = How.Name, Using = "Amount")]
        private IWebElement AmountField;

        public IWebElement GetAmountField()
        {
            return AmountField;
        }
    }
}
