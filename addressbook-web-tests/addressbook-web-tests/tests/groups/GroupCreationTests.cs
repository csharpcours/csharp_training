using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
                  
            GroupData groupData = new GroupData("testName");
            groupData.GroupFooter = "FooterName";
            manager.Groups.Create(groupData);            
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            

            GroupData groupData = new GroupData("");
            groupData.GroupFooter = "";
            manager.Groups.Create(groupData);
        }
    }
}
