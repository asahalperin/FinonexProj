using Finonex.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Finonex.PageObjects
{
    public class SignUpThird
    {
        private IWebDriver driver;

        public SignUpThird(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToDisplay()
        {
            Wait.UntilElementIsClickable(driver, YearBirthDate, 20, 350);
        }

        public SignUpFourth ValidThirdStep(string currency, string password, string day, string month, string year)
        {
            Select.FromDropDown(driver, CurrencyDropDown, currency, "Currency drop down");
            Update.Text(driver, PasswordField, password, "Password field");
            Update.Text(driver, DayBirthDate, day, "Day birhtday field");
            Update.Text(driver, MonthBirthDate, month, "Month birthday field");
            Update.Text(driver, YearBirthDate, year, "Year birthday field");
            Click.Go(driver, NextButton3, "Next button");
            return new SignUpFourth(driver);
        }

        [FindsBy(How = How.Name, Using = "Currency")]
        private IWebElement CurrencyDropDown;

        [FindsBy(How = How.XPath, Using = "//input[@name='Password' and @placeholder='*Password']")]
        private IWebElement PasswordField;

        [FindsBy(How = How.Name, Using = "DateOfBirthDay")]
        private IWebElement DayBirthDate;

        [FindsBy(How = How.Name, Using = "DateOfBirthMonth")]
        private IWebElement MonthBirthDate;

        [FindsBy(How = How.Name, Using = "DateOfBirth")]
        private IWebElement YearBirthDate;

        [FindsBy(How = How.Name, Using = "BtnStep4Next")]
        private IWebElement NextButton3;

        public IWebElement GetCurrencyDropDown()
        {
            return CurrencyDropDown;
        }

        public IWebElement GetPasswordField()
        {
            return PasswordField;
        }

        public IWebElement GetDateOfBirthDay()
        {
            return DayBirthDate;
        }

        public IWebElement GetDateOfBirthMonth()
        {
            return MonthBirthDate;
        }

        public IWebElement GetDateOfBirthYear()
        {
            return YearBirthDate;
        }

        public IWebElement GetNextButton3()
        {
            return NextButton3;
        }
    }
}
