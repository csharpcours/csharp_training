using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserModificationTests : TestBase
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
            manager.Users.Modification(1,userData);
        }

    }
}
