using Finonex.Extensions;
using OpenQA.Selenium;

namespace Finonex.Utilities
{
    public class User
    {
        public static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static string nums = "0123456789";
        private string firstName, lastName, email, password, phoneNumber;
        public static string text;
        private static string realAccount;
        public User(string firstName, string lastName, string email, string password, string realAccount, string phoneNumber) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
        this.phoneNumber = phoneNumber;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string RealAccount
        {
            get { return realAccount; }
            set { realAccount = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public static User RandomUser = new User("Test" + RandomGenerator.GenerateRandom(4, chars), 
            "Test" + RandomGenerator.GenerateRandom(4, chars), 
            RandomGenerator.GenerateRandom(6, chars + nums) + "@mailinator.com", 
            "Qa" + RandomGenerator.GenerateRandom(6, nums), 
            text, 
            RandomGenerator.GenerateRandom(8, nums));

        public static void RealAccountText(IWebDriver driver, IWebElement elem, int seconds, string elemName)
        {
            text = Pull.TextFromElement(driver, elem, seconds, elemName);
            realAccount = text;
        }
       
    }
}
