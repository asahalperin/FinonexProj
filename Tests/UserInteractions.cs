using Finonex.Extensions;
using Finonex.PageObjects;
using Finonex.Utilities;


namespace Finonex.Tests
{
    class UserInteractions : Base
    {
        [Test, Order(1)]
        public void ValidSignUp()
        {
            SignUpPage signUpPage = new SignUpPage(driver);
            SignUpSecond secondPage = signUpPage.ValidFirstStep(User.RandomUser.FirstName, User.RandomUser.LastName, User.RandomUser.Email, User.RandomUser.PhoneNumber);
            secondPage.WaitForPageToDisplay();
            SignUpThird thirdPage = secondPage.ValidSecondStep("Togo", "Bulgaria 23/12", "Sofia", "234523452345");
            thirdPage.WaitForPageToDisplay();
            SignUpFourth fourthPage = thirdPage.ValidThirdStep("USD", User.RandomUser.Password, "12", "5", "1985");
            fourthPage.WaitForPageToDisplay();
            //The followong page (5th) is missing on my test run:
            /*SignUpFifth fifthPage = fourthPage.validFourthStep("Employed", "$15,000-$50,000", "Employment", "Less than $5,000", "Capital Growth");
            fifthPage.waitForPageToDisplay();
            fifthPage.validFifthStep("Yes, from a relevant role in financial services","Less than 6 months", "I trade FX & CFDs 1-2 times a month.", "Between 1 and 2 years", "I trade 1-2 times a month.");*/
            SignUpSixth sixthPage = fourthPage.ValidFourthStep("Employed", "$15,000-$50,000", "Employment", "Less than $5,000", "Capital Growth");
            sixthPage.WaitForPageToDisplay();
            PaymentPage payment = sixthPage.ValidSixthStep();
            AccountPage account = payment.NavigateToAccount("https://www.fortrade.com/my-account/?regType=r");
            account.WaitForPageToDisplay();
            account.PullRealAccountId();
            Verify.TextContains(driver, driver.Url, "/my-account/?regType=r", "URL");
        }

        [Test, Order(2)]
        public void ValidRealAccountLogin()
        {
            HomePage homePage = new HomePage(driver);
            AccountPage account = homePage.Login(User.RandomUser.RealAccount, User.RandomUser.Password);
            account.WaitForPageToDisplay();
            string actualAccount = Pull.TextFromElement(driver, account.GetRealAccountId(), 20, "Real account field");
            Verify.TextEquals(driver, actualAccount, User.RandomUser.RealAccount, "Text of real account");
        }

        [Test, Order(3)]
        public void ValidEmailLogin()
        {
            HomePage homePage = new HomePage(driver);
            AccountPage account = homePage.Login(User.RandomUser.Email, User.RandomUser.Password);
            account.WaitForPageToDisplay();
            string actualAccount = Pull.TextFromElement(driver, account.GetRealAccountId(), 20, "Real account field");
            Verify.TextEquals(driver, actualAccount, User.RandomUser.RealAccount, "Text of real account");
        }
    }
}
