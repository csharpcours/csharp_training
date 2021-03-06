﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContractHelper : HelperBase
    {
        public ContractHelper(ApplicationManager manager) : base(manager)
        {
        }

        public UserData GetContactInformationEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            
            InitUserModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string midleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string secondaryHome = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new UserData(firstName, lastName)
            {
                MidleName = midleName,
                Address = address,
                Home= homePhone,
                Work= workPhone,
                Mobile=mobilePhone,
                SecondaryHome=secondaryHome,
                Email1= email1,
                Email2 = email2,
                Email3 = email3
            };
        }

        public UserData GetContactInformationFromDetal(int index)
        {
            manager.Navigator.OpenHomePage();
            InitUserDetal(index);
            string allContact = driver.FindElement(By.Id("content")).Text;
            return new UserData(null)
            {
                AllContact = allContact
            };

        }

        private void InitUserDetal(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                 .FindElements(By.TagName("td"))[6]
                 .FindElement(By.TagName("a")).Click();
        }
        public void AddContactToGroup(UserData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.GroupName);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        private void SelectContact(string contactid)
        {
            driver.FindElement(By.Id(contactid)).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public ContractHelper Remove(UserData contact)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(contact.Id);
            RemoveUser();
            SubmitUserDeleteCloseAlert();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            return this;
        }
        private void SelectGroupToDel(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        private void CommitDeleteContactToGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }
        public void DeleteContactFromGroup(UserData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            SelectGroupToDel(group.GroupName);
            SelectContact(contact.Id);
            CommitDeleteContactToGroup();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }
    public UserData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
           IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                    .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            
            string allEmails = cells[4].Text;

            return new UserData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
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

        internal int GetUserCount()
        {
            return driver.FindElements(By.CssSelector("img[alt=\"Edit\"]")).Count;
        }

        public bool CheckContact()
        {
            manager.Navigator.OpenHomePage();
            return IsElementPresent(By.CssSelector("img[alt=\"Edit\"]"));
        }

        private List<UserData> contactCache =null;

        public List<UserData> GetContactList()
        {
            manager.Navigator.OpenHomePage();
            List<UserData> contacts = new List<UserData>();
            ICollection < IWebElement> Rows =new List<IWebElement>(driver.FindElements(By.Name("entry")));

            if (contactCache == null)
            {
                contactCache = new List<UserData>();
                foreach (var row in Rows)
                {


                    var cells = row.FindElements(By.TagName("td"));
                    UserData contact = new UserData(cells[2].Text);
                    contact.Lastname = cells[1].Text;
                    contactCache.Add(contact);                    
                }
            }
            return new List<UserData>(contactCache);

        }

        public ContractHelper Create(UserData userData)
        {
            manager.Navigator.GoToUserCreationPage();
            FillUserForm(userData);
            SubmitUserCreation();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContractHelper Modification(UserData userData)
        {
            manager.Navigator.OpenHomePage();
            InitUserModification();
            FillUserForm(userData);
            SubmitUserModification();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContractHelper Remove(int v)
        {
            manager.Navigator.OpenHomePage();
            SelectUser(v);
            RemoveUser();
            SubmitUserDeleteCloseAlert();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContractHelper SubmitUserCreation()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            contactCache = null;
            return this;
        }
       
        public ContractHelper SelectUser(int index)
        {
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index+1 + "]")))
            {
                UserData userData = new UserData("FirstName", "LastName");
                Create(userData);                
            }
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index+1 + "]")).Click();
            return this;
        }
        public ContractHelper RemoveUser()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
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
        public ContractHelper InitUserModification()  //(int ind)
        {
            //driver.FindElement(By.Name("entry"))[ind]
            //    .FindElement(By.TagName("td"))[7]
            //    .FindElement(By.TagName("a")).Click();

            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }
        public ContractHelper InitUserModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            
          //  driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContractHelper SubmitUserModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public int GetNumberOffresults()
        {
            manager.Navigator.OpenHomePage();
           string text =  driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);

            return Int32.Parse(m.Value);
        }

    }
}
