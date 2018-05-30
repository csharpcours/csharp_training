﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
  public  class ApplicationManager
    {
        protected IWebDriver driver;
        protected IAlert alert;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContractHelper userHelper;
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public IAlert Alert
        {
            get
            {
                return alert;
            }
        }

        public string BaseURL
        {
            get { return baseURL; }
        }
        public ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Users\User\Desktop\firefox-sdk\bin\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this,baseURL);
            groupHelper = new GroupHelper(this);
            userHelper = new ContractHelper(this);
        }
        public void Quit()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {

            }
        }
        public LoginHelper LogOnOff
        {
            get
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContractHelper Users
        {
            get
            {
                return userHelper;
            }
        }

      
    }
}