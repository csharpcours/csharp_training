using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager manager;

        [SetUp]
        public void SetupTest()
        {
            manager = new ApplicationManager();
            manager.Navigator.OpenHomePage();
            manager.LogOnOff.Login(new AccountData("admin", "secret"));
        }
        
        [TearDown]
        public void TeardownTest()

        {
            manager.LogOnOff.Logout();
            manager.Quit();
        }
    }
}
