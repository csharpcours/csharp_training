using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
                  
            GroupData groupData = new GroupData("testName");
            groupData.GroupFooter = "FooterName";
            app.Groups.Create(groupData);            
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            

            GroupData groupData = new GroupData("");
            groupData.GroupFooter = "";
            app.Groups.Create(groupData);
        }
    }
}
