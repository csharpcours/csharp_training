using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserRemoveTests : AuthTestBase
    {
        [Test]

        public void UserRemoveTest()
        {
            app.Users.Remove(1);
        }
    }
}
