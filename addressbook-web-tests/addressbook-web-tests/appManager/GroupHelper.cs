﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData groupData)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(groupData);
            SubmitGroupCreation();
            return this;
        }

        public GroupHelper Modify(int v,GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            RemoveGroup();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
            {
                GroupData groupData = new GroupData("testName");
                InitGroupCreation();
                FillGroupForm(groupData);
                SubmitGroupCreation();
                manager.Navigator.GoToGroupPage();                
            }
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData groupData)
        {
            Type(By.Name("group_name"), groupData.GroupName);
            Type(By.Name("group_header"), groupData.GroupHeader);
            Type(By.Name("group_footer"), groupData.GroupFooter);
            return this;
        }

      
        
    }
}
