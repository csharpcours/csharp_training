using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserModificationTests : AuthTestBase
    {
        [Test]
        public void UserModificationTest()
        {

            UserData userData = new UserData("ModifFirstName");
            userData.Lastname = "ModifLastName";
            userData.MidleName = "ModifMiddleName";
            userData.Nickname = "ModifNickname";
            userData.Title = "ModifTitle";
            userData.Company = "ModifCompany";
            userData.Address = "ModifAddress";
            userData.Home = "ModifHome";
            userData.Mobile = "ModifMobile";
            userData.Work = "ModifWork";
            userData.Fax = "ModifFax";
            userData.Email1 = "ModifEmail1";
            userData.Email2 = "ModifEmail2";
            userData.Email3 = "ModifEmail3";
            userData.Homepage = "ModifHomepage";
            userData.SecondaryHome = "ModifSecondaryHome";
            userData.SecondaryAddress = "ModifSecondaryAddress";
            userData.Notes = "ModifNotes";
            userData.Year = "1988";
            userData.Ayear = "1988";

            if (!app.Users.CheckContact())
            {
                UserData createData = new UserData("CreateForModifFirstName", "CreateForModifLastName");
                app.Users.Create(createData);
            }

            List<UserData> oldContacts = app.Users.GetContactList();
            app.Users.Modification(userData);

            List<UserData> newContacts = app.Users.GetContactList();
            oldContacts[0].Lastname = userData.Lastname;
            oldContacts[0].FirstName = userData.FirstName;
            //oldContacts.Add(userData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            
           // Assert.IsTrue((app.Users.CheckContact()));
        }

    }
}
