using Finonex.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Finonex.PageObjects
{
    //This Page object class is not used beacuse the page is not part of the flow on my test run
    public class SignUpFifth
    {
        private IWebDriver driver;

        public SignUpFifth(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToDisplay()
        {
            Wait.UntilElementIsClickable(driver, KnowledgeDropDown, 20, 350);
        }

        public void ValidFifthStep(string knowledge, string trading, string frequencyTrading, string otherExperience, string frequencyOther)
        {
            Select.FromDropDown(driver, KnowledgeDropDown, knowledge, "Knowledge drop down");
            Select.FromDropDown(driver, TradingExperienceDropDown, trading, "Trading drop down");
            Select.FromDropDown(driver, FrequencyDropDown, frequencyTrading, "Frequency drop down");
            Select.FromDropDown(driver, OtherExperienceDropDown, otherExperience, "Other experience drop down");
            Select.FromDropDown(driver, FrequencyOtherTradingDropDown, frequencyOther, "Frequency other trading drop down");
            Click.Go(driver, NextButton5, "Next button");
            //return new SignUpSixth(driver);
        }

        [FindsBy(How = How.Name, Using = "KnowledgeOfTrading")]
        private IWebElement KnowledgeDropDown;

        [FindsBy(How = How.Name, Using = "TradingExperience")]
        private IWebElement TradingExperienceDropDown;

        [FindsBy(How = How.Name, Using = "FrequencyOfTrades")]
        private IWebElement FrequencyDropDown;

        [FindsBy(How = How.Name, Using = "OtherTradingExperience")]
        private IWebElement OtherExperienceDropDown;

        [FindsBy(How = How.Name, Using = "FrequencyOtherTradingExperience")]
        private IWebElement FrequencyOtherTradingDropDown;

        [FindsBy(How = How.Name, Using = "BtnStep7Next")]
        private IWebElement NextButton5;

        public IWebElement GetKnowledge()
        {
            return KnowledgeDropDown;
        }

        public IWebElement GetTrading()
        {
            return TradingExperienceDropDown;
        }

        public IWebElement GetFrequencyOfTrades()
        {
            return FrequencyDropDown;
        }

        public IWebElement GetOtherTrading()
        {
            return OtherExperienceDropDown;
        }

        public IWebElement GetFrequencyOther()
        {
            return FrequencyOtherTradingDropDown;
        }

        public IWebElement GetNextButton5()
        {
            return NextButton5;
        }
    }
}
