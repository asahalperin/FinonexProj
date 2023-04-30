using Finonex.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Finonex.PageObjects
{
    public class SignUpPage
    {
        private IWebDriver driver;

        public SignUpPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public SignUpSecond ValidFirstStep(string firstName, string lastName, string email, string phone)
        {
            Update.Text(driver, FirstNameField, firstName, "First name field");
            Update.Text(driver, LastNameField, lastName, "Last name field");
            Update.Text(driver, EmailAddressField, email, "Email field");
            Update.Text(driver, PhoneField, phone, "Phone field");
            Click.Go(driver, NextButton1, "Next button");
            return new SignUpSecond(driver);
        }

        [FindsBy(How = How.Name, Using = "FirstName")]
        private IWebElement FirstNameField;

        [FindsBy(How = How.Name, Using = "LastName")]
        private IWebElement LastNameField;

        [FindsBy(How = How.Name, Using = "Email")]
        private IWebElement EmailAddressField;

        [FindsBy(How = How.Name, Using = "Phone")]
        private IWebElement PhoneField;

        [FindsBy(How = How.Name, Using = "BtnNext")]
        private IWebElement NextButton1;

        public IWebElement GetFirstNameField()
        {
            return FirstNameField;
        }

        public IWebElement GetLastNameField()
        {
            return LastNameField;
        }

        public IWebElement GetEmailAdressField()
        {
            return EmailAddressField;
        }

        public IWebElement GetPhoneField()
        {
            return PhoneField;
        }

        public IWebElement GetNextButton()
        {
            return NextButton1;
        }
    }
}
