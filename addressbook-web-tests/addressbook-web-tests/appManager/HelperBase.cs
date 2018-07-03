using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;
        protected IAlert alert;

        public HelperBase(ApplicationManager manager)
        {
            driver = manager.Driver;
            alert = manager.Alert;
            this.manager = manager;
            
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }

        }
        public string TextByElementOnPage(string texts)
        {
            // driver.FindElement(By.XPath("//*[@id = 'content']/form/span/text(),'"texts");
            //driver.FindElement(By.XPath("//*[@id = 'content']/form/span/(text(),'"texts"')));
            //var TextByElement = driver.FindElement(By.XPath("//*[.="+texts+"]"));
           // var TextByElement = driver.FindElement(By.XPath("span[@class="group"]//input"));
           // var TextByElement = driver.FindElement(By.Name("selected[]")).Click();
           
            var TextByElement = driver.FindElement(By.XPath("//span[@title='title = 'Select(" + texts + ")']"));
            // title = "Select (ModifytestName)"
            //*[@id="content"]/form/span/text()
            //*[@id="content"]/form/span
            //*[@id="content"]/form/span/(text(), '+texts+')
            //   [@id="content"]/form/span/text()
            Console.WriteLine(TextByElement);
            return TextByElement.Text;
             
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
