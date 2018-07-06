using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserRemoveTests : ContactTestBase
    {
        [Test]

        public void UserRemoveTest()
        {
            if (!app.Users.CheckContact())
            {
                UserData createData = new UserData("CreateForModifFirstName", "CreateForModifLastName");
                app.Users.Create(createData);
            }
            List<UserData> oldContacts = UserData.GetAll();//app.Users.GetContactList();
            UserData toBeRemove = oldContacts[0];
            app.Users.Remove(toBeRemove);

            Assert.AreEqual(oldContacts.Count - 1, app.Users.GetUserCount());

            List<UserData> newContacts = UserData.GetAll();//app.Users.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);          
        }
    }
}
