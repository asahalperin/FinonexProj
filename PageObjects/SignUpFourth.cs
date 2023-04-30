using Finonex.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Finonex.PageObjects
{
    public class SignUpFourth
    {
        private IWebDriver driver;

        public SignUpFourth(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToDisplay()
        {
            Wait.UntilElementIsClickable(driver, EmploymentStatusDropDown, 20, 350);
        }

        public SignUpSixth ValidFourthStep(string employment, string estimated, string source, string value, string reason)
        {
            Select.FromDropDown(driver, EmploymentStatusDropDown, employment, "Employment status drop down");
            Select.FromDropDown(driver, EstimatedAnnualIncomeDropDown, estimated, "Estimated annual income drop down");
            //The following lines in comment beacuse their fields are missimng on my test run:
            /*Select.fromDropDown(driver, sourceOfFundsDropDown, source);
            Select.fromDropDown(driver, valueOfSavingDropDown, value);
            Select.fromDropDown(driver, reasonForTrading, reason);*/
            Click.Go(driver, GetNextButton4(), "Next button");
            return new SignUpSixth(driver);
        }

        [FindsBy(How = How.Name, Using = "EmploymentStatus")]
        private IWebElement EmploymentStatusDropDown;

        [FindsBy(How = How.Name, Using = "EstimatedAnnualIncome")]
        private IWebElement EstimatedAnnualIncomeDropDown;

        [FindsBy(How = How.Name, Using = "SourceofFunds")]
        private IWebElement SourceOfFundsDropDown;

        [FindsBy(How = How.Name, Using = "ValueOfSavingAndInvestments")]
        private IWebElement ValueOfSavingDropDown;

        [FindsBy(How = How.Name, Using = "InvestmentObjectives")]
        private IWebElement ReasonForTrading;

        [FindsBy(How = How.Name, Using = "BtnStep5Next")]
        private IWebElement NextButton4;

        public IWebElement GetEmploymentStatus()
        {   
            return EmploymentStatusDropDown;
        }

        public IWebElement GetEstimatedAnnual()
        {
            return EstimatedAnnualIncomeDropDown;
        }

        public IWebElement GetSourceOfFunds()
        {
            return SourceOfFundsDropDown;
        }

        public IWebElement GetValueOfSaving()
        {
            return ValueOfSavingDropDown;
        }

        public IWebElement GetInvestmentObjectives()
        {
            return ReasonForTrading;
        }

        public IWebElement GetNextButton4()
        {
            return NextButton4;
        }
    }
}
