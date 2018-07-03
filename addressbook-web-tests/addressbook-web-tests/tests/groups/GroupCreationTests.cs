using NUnit.Framework;
using System.Collections.Generic;


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

            List<GroupData> oldGroups =app.Groups.GetGroupist();
            app.Groups.Create(groupData);

            List<GroupData> newGroups = app.Groups.GetGroupist();
            Assert.AreEqual(oldGroups.Count+1,newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {       
            GroupData groupData = new GroupData("");
            groupData.GroupFooter = "";
            List<GroupData> oldGroups = app.Groups.GetGroupist();
            app.Groups.Create(groupData);

            List<GroupData> newGroups = app.Groups.GetGroupist();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData groupData = new GroupData("a'a");
            groupData.GroupFooter = "";
            List<GroupData> oldGroups = app.Groups.GetGroupist();
            app.Groups.Create(groupData);

            List<GroupData> newGroups = app.Groups.GetGroupist();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
