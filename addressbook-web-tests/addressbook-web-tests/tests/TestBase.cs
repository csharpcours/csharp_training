using NUnit.Framework;


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

        //[TearDown]
        //public void StopApplicationManager()
        //{
        //    ApplicationManager.GetInstance().LogOnOff.Logout();
        //}

    }
}
