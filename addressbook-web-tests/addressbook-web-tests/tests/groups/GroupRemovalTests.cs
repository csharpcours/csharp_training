
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    { 
        [Test]
        public void GroupRemovalTest()
        {
            //  manager.Navigator.GoToGroupPage();
            manager.Groups.Remove(1);


        }
    }
}
