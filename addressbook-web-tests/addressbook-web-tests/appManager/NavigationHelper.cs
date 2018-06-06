using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager,string baseUrl) : base(manager)
        {
            this.baseURL =manager.BaseURL;
        }
        public void GoToGroupPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php" &&
                IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToUserCreationPage()
        {
            if (driver.Url == baseURL + "/addressbook/edit.php")
            //&& driver.FindElement(By.CssSelector("input[type=\"submit\"]"))
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
