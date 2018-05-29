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

    }
}
