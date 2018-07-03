using System;
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
            manager.Navigator.GoToGroupPage();
            return this;
        }

        public List<GroupData> GetGroupist()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupPage();
            ICollection<IWebElement> elements= driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                 groups.Add( new GroupData(element.Text));
            }
            return groups;
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public bool CheckGroup()
        {
            manager.Navigator.GoToGroupPage();
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (1) + "]"));
          //  return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]"));
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
