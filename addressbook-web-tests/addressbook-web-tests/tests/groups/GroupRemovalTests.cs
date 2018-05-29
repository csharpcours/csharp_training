using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    { 
        [Test]
        public void GroupRemovalTest()
        {
            manager.Groups.Remove(1);
        }
    }
}
