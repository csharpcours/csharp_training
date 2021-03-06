﻿using System;
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
            if (isLoggedIn())
            {
                if (isLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.UserName);
            Type(By.Name("pass"), account.Pass);
            //driver.FindElement(By.Name("user")).Clear();
            //driver.FindElement(By.Name("user")).SendKeys(account.UserName);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public bool isLoggedIn(AccountData account)
        {
            return isLoggedIn()
                 && GetLoggetUserName() == account.UserName;

        }

        private string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public bool isLoggedIn()
        {
          return  IsElementPresent(By.Name("logout"));
        }

        public void Logout()
        {
            if(isLoggedIn())
            { 
            driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
    }
}
