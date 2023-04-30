using AventStack.ExtentReports;
using Finonex.Extensions;
using Finonex.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Finonex.PageObjects
{
    public class HomePage : Base
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LogOut()
        {
            try 
            {
                Click.Go(driver, UserMenuButton, "User menu button");
                Click.Go(driver, LogOutButton, "Logout button");
            }
            catch {
                test.Log(Status.Info, "Failed to click main Logout button, trying again with secondary button");
                Click.Go(driver, SecondaryLogoutButton, "Secondary logout button");
            }
            Wait.UntilElementIsClickable(driver, SignUpButton, 20, 350);
        }

        public AccountPage Login(string user, string password)
        {
            Click.Go(driver, LoginButton, "Login button");
            Wait.UntilElementIsClickable(driver, PasswordField, 20, 350);
            Update.Text(driver, AccountEmailField, user, "Account email field");
            Update.Text(driver, PasswordField, password, "Password field");
            Click.Go(driver, LoginSubmitButton, "Submit login button");
            return new AccountPage(driver);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@class, 'headerSignUpBtn')]")]
        private IWebElement SignUpButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'headerLoginBtn')]")]
        private IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='clientMenuLinks']/a[contains(@class, 'manageInfoLink')]/following-sibling::a[contains(@class, 'Logout')]")]
        private IWebElement LogOutButton;

        [FindsBy(How = How.Name, Using = "LoginSubmit")]
        private IWebElement LoginSubmitButton;

        [FindsBy(How = How.ClassName, Using = "userHead")]
        private IWebElement UserMenuButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='loggedUser']/div[contains(@class, 'opened')]")]
        private IWebElement UserMenuOpen;

        [FindsBy(How = How.Name, Using = "AccountName")]
        private IWebElement AccountEmailField;

        [FindsBy(How = How.Name, Using = "Password")]
        private IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'headerLogout ')]")]
        private IWebElement SecondaryLogoutButton;

        public IWebElement GetSignUpButton()
        {
            return SignUpButton;
        }

        public IWebElement GetLoginButton()
        {
            return LoginButton;
        }

        public IWebElement GetLogOutButton()
        {
            return LogOutButton;
        }

        public IWebElement GetLoginSubmitVutton()
        {
            return LoginSubmitButton;
        }
 
        public IWebElement GetUserMenuButton()
        {
            return UserMenuButton;
        }

        public IWebElement GetUserMenuOpen()
        {
            return UserMenuOpen;
        }

        public IWebElement GetAccountEmailField()
        {
            return AccountEmailField;
        }

        public IWebElement GetPasswordField()
        {
            return PasswordField;
        }
    }
}
