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
        private List<GroupData>  groupCache=null;

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                //List<GroupData> groups = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    GroupData group = new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    };
                    groupCache.Add(group);
                }
                string AllGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
               string [] parts= AllGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].GroupName = "";
                    }
                    else
                    {
                        groupCache[i].GroupName = parts[i-shift].Trim();
                    }
                }
            }
            
            return new List<GroupData>(groupCache);
        }

        public GroupHelper Modify(int v,GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.GoToGroupPage();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
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
            manager.Navigator.GoToGroupPage();
            return this;
        }

        public GroupHelper Modify(GroupData group, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(group.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.GoToGroupPage(); 
            return this;
        }
        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(group.Id);
            RemoveGroup();
            manager.Navigator.GoToGroupPage();
            return this;
        }
        public GroupHelper SelectGroup(string id)
       {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '"+id+"'])")).Click();
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
            groupCache = null;
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
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
