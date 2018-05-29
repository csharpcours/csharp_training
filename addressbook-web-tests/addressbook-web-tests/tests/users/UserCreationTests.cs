using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : TestBase
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
            manager.Users.Create(userData);
        }             
    }
}
