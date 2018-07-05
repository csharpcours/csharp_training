using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : AuthTestBase
    {            

        [Test]
        public void UserCreationTest()
        {    
            UserData userData = new UserData("FirstName", "LastName");
            userData.MidleName = "MiddleName";
            userData.Nickname = "Nickname";
            userData.Title = "Title";
            userData.Company = "Company";
            userData.Address = "Address";
            userData.Home = "Home";
            userData.Mobile = "Mobile";
            userData.Work = "Work";
            userData.Fax = "Fax";
            userData.Email1 = "Email1";
            userData.Email2 = "Email2";
            userData.Email3 = "Email3";
            userData.Homepage = "Homepage";
            userData.SecondaryHome = "SecondaryHome";
            userData.SecondaryAddress = "SecondaryAddress";
            userData.Notes = "Notes";
            userData.Year = "1988";
            userData.Ayear = "1988";

            List<UserData> oldContacts = app.Users.GetContactList();
            app.Users.Create(userData);

            List<UserData> newContacts = app.Users.GetContactList();
            oldContacts.Add(userData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }

        [Test]
        public void BadNameUserCreationTest()
        {
            UserData userData = new UserData("A'A", "LastName");
            
            List<UserData> oldContacts = app.Users.GetContactList();
            app.Users.Create(userData);
            List<UserData> newContacts = app.Users.GetContactList();
            Assert.AreEqual(oldContacts.Count , newContacts.Count);
            //Assert.AreEqual(oldContacts.Count+1, newContacts.Count);
        }
    }
}
