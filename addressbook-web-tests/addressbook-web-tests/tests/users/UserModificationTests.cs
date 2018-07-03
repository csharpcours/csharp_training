using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserModificationTests : AuthTestBase
    {
        [Test]
        public void UserModificationTest()
        {

            UserData userData = new UserData("ModifFirstName", "ModifLastName");
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
            app.Users.Modification(userData);
           // Assert.IsTrue((app.Users.CheckContact()));
        }

    }
}
