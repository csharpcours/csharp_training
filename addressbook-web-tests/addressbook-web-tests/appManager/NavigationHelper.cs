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
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
        public void GoToUserCreationPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

    }
}
