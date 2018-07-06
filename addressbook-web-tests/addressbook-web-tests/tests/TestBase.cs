using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupAppicationManager()
        {
            app = ApplicationManager.GetInstance();          
        }
        public static Random rnd = new Random();
        public static string GeneraterandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int q=0; q < l; q++)
            {
                builder.Append(Convert.ToChar(32+Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
        //[TearDown]
        //public void StopApplicationManager()
        //{
        //    ApplicationManager.GetInstance().LogOnOff.Logout();
        //}

    }
}
