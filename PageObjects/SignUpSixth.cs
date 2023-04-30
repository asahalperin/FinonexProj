using Finonex.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Finonex.PageObjects
{
    public class SignUpSixth
    {
        private IWebDriver driver;

        public SignUpSixth(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToDisplay()
        {
            Wait.UntilElementIsClickable(driver, AgreementCheckBox, 20, 350);
        }

        public PaymentPage ValidSixthStep()
        {
            Click.Go(driver, AgreementCheckBox, "Agreement checkbox");
            Thread.Sleep(1000);
            Click.Submit(driver, SendButton, "Send button");
            WindowsHandle.CloseAditioalWindow(driver, 10, "https://ready.fortrade.com/");
            return new PaymentPage(driver);
        }

        [FindsBy(How = How.Name, Using = "MarketingMaterials")]
        private IWebElement MarketingCheckBox;

        [FindsBy(How = How.XPath, Using = "//span[@for='TermsAgreement']/div[@class='fscClass']/strong")]
        private IWebElement AgreementCheckBox;

        [FindsBy(How = How.Name, Using = "Send")]
        private IWebElement SendButton;

        public IWebElement GetMarketingCheckBox()
        {
            return MarketingCheckBox;
        }

        public IWebElement GetTermsAgreementCheckBox()
        {
            return AgreementCheckBox;
        }

        public IWebElement GetSendButton()
        {
            return SendButton;
        }

    }
}
