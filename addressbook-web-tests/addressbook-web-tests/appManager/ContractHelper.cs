using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WebAddressbookTests
{
    public class ContractHelper : HelperBase
    {
        public ContractHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContractHelper FillUserForm(UserData userData)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(userData.FirstName);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(userData.MidleName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(userData.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(userData.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(userData.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(userData.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(userData.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(userData.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(userData.Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(userData.Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(userData.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(userData.Email1);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(userData.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(userData.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(userData.Homepage);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(userData.SecondaryHome);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(userData.SecondaryAddress);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(userData.Notes);

            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("17");
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("March");
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(userData.Year);
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(userData.Ayear);
            //new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("q");
            //new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("[none]");
            return this;
        }

        public ContractHelper Modification(int d, UserData userData)
        {            
            SelectUser(d);
            InitUserModification();
            FillUserForm(userData);
            SubmitUserModification();
            return this;
        }


        public ContractHelper Create(UserData userData)
        {
            manager.Navigator.GoToUserCreationPage();
            FillUserForm(userData);
            SubmitUserCreation();
            return this;
        }

        public ContractHelper Remove(int v)
        {
            SelectUser(v);
            RemoveUser();
            SubmitUserDeleteCloseAlert();
            return this;
        }

        public ContractHelper SubmitUserCreation()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }
       
        public ContractHelper SelectUser(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public ContractHelper RemoveUser()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();            
            return this;            
        }
        public ContractHelper SubmitUserDeleteCloseAlert()
        {
            alert= driver.SwitchTo().Alert();
            Thread.Sleep(1000);
            alert.Accept();
            // IAlert alert = driver.SwitchTo().Alert();
            return this;
        }
        public ContractHelper InitUserModification()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContractHelper SubmitUserModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

    }
}
