using Finonex.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Finonex.PageObjects
{
    public class SignUpSecond
    {
        private IWebDriver driver;

        public SignUpSecond(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToDisplay()
        {
            Wait.UntilElementIsClickable(driver, ZipCodeField, 20, 350);
        }

        public SignUpThird ValidSecondStep(string country, string address, string city, string zip)
        {
            Select.FromDropDown(driver, CountryDropDown, country, "Country drop down");
            Update.Text(driver, AddressField, address, "Address field");
            Update.Text(driver, CityField, city, "City field");
            Update.Text(driver, ZipCodeField, zip, "Zip code field");
            Click.Go(driver, NextButton2, "Next button");
            return new SignUpThird(driver);
        }

        [FindsBy(How = How.Name, Using = "Country")]
        private IWebElement CountryDropDown;

        [FindsBy(How = How.Name, Using = "Address")]
        private IWebElement AddressField;

        [FindsBy(How = How.Name, Using = "City")]
        private IWebElement CityField;

        [FindsBy(How = How.Name, Using = "ZipCode")]
        private IWebElement ZipCodeField;

        [FindsBy(How = How.Name, Using = "BtnNext2")]
        private IWebElement NextButton2;

        public IWebElement GetCountryDropDown()
        {
            return CountryDropDown;
        }

        public IWebElement GetAddressField()
        {
            return AddressField;
        }

        public IWebElement GetCityField()
        {
            return CityField;
        }

        public IWebElement GetZipCodeField()
        {
            return ZipCodeField;
        }

        public IWebElement GetNextButton2()
        {
            return NextButton2;
        }
    }
}
