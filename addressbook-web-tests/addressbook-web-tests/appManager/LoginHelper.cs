using OpenQA.Selenium;


namespace WebAddressbookTests
{
   public class LoginHelper: HelperBase
    {

        public LoginHelper(ApplicationManager manager) : base(manager)
        { 
        }

        public void Login(AccountData account)
        {
            Type(By.Name("user"), account.UserName);
            Type(By.Name("pass"), account.Pass);
            //driver.FindElement(By.Name("user")).Clear();
            //driver.FindElement(By.Name("user")).SendKeys(account.UserName);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
