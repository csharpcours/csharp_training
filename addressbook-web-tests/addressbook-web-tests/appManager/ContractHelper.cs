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
            Type(By.Name("firstname"), userData.FirstName);
            Type(By.Name("middlename"), userData.MidleName);
            Type(By.Name("lastname"), userData.Lastname);
            Type(By.Name("nickname"), userData.Nickname);
            Type(By.Name("title"), userData.Title);
            Type(By.Name("company"), userData.Company);
            Type(By.Name("address"), userData.Address);
            Type(By.Name("home"), userData.Home);
            Type(By.Name("mobile"), userData.Mobile);
            Type(By.Name("work"), userData.Work);
            Type(By.Name("fax"), userData.Fax);
            
            Type(By.Name("email"), userData.Email1);
            Type(By.Name("email2"), userData.Email2);
            Type(By.Name("email3"), userData.Email3);
            Type(By.Name("homepage"), userData.Homepage);
            Type(By.Name("phone2"), userData.SecondaryHome);
            Type(By.Name("address2"), userData.SecondaryAddress);
            Type(By.Name("notes"), userData.Notes);
            Type(By.Name("byear"), userData.Year);
            Type(By.Name("ayear"), userData.Ayear);

            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(userData.Year);
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(userData.Ayear);
            //new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("q");
            //new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("[none]");
            return this;
        }

        public ContractHelper Modification(UserData userData)
        {            
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
