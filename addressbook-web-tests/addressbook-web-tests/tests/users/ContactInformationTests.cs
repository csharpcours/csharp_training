using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserInformationTests : AuthTestBase
    { 

        [Test]
        public void TestUserInformation()
        {
            UserData fromTable = app.Users.GetContactInformationFromTable(0);
            UserData fromEditForm = app.Users.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);
        }
    }
}
