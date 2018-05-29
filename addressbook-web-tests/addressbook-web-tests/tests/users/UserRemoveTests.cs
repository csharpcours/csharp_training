using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserRemoveTests : TestBase
    {
        [Test]

        public void UserRemoveTest()
        {
            manager.Users.Remove(1);
        }
    }
}
