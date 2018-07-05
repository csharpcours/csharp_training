using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserRemoveTests : AuthTestBase
    {
        [Test]

        public void UserRemoveTest()
        {
            if (!app.Users.CheckContact())
            {
                UserData createData = new UserData("CreateForModifFirstName", "CreateForModifLastName");
                app.Users.Create(createData);
            }
            List<UserData> oldContacts = app.Users.GetContactList();
            app.Users.Remove(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Users.GetUserCount());

            List<UserData> newContacts = app.Users.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);          
        }
    }
}
