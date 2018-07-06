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
            UserData fromEditForm  = app.Users.GetContactInformationEditForm(0);

            UserData fromTable = app.Users.GetContactInformationFromTable(0);


            Assert.AreEqual(fromTable, fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);
        }
        [Test]
        public void TestDetalInform()
        {
            UserData fromEditForm = app.Users.GetContactInformationEditForm(0);
            UserData fromDetal = app.Users.GetContactInformationFromDetal(0);

            //System.Console.Out.Write(fromDetal.AllContact);
            //System.Console.Out.Write(fromEditForm.AllContact);
            // Assert.AreEqual(fromDetal.AllEmails, fromEditForm.AllEmails);            
             Assert.AreEqual(fromDetal.AllContact, fromEditForm.AllContact);
        }
    }
}
