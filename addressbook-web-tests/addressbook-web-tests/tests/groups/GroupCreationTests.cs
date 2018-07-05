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

            List<GroupData> oldGroups =app.Groups.GetGroupList();
            app.Groups.Create(groupData);
            oldGroups.Add(groupData);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            //Assert.AreEqual(oldGroups.Count+1,newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {       
            GroupData groupData = new GroupData("");
            groupData.GroupFooter = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            oldGroups.Add(groupData);
            app.Groups.Create(groupData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            
            Assert.AreEqual(oldGroups, newGroups);
            //Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData groupData = new GroupData("a'a");
            groupData.GroupFooter = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            oldGroups.Add(groupData);
            app.Groups.Create(groupData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            //Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
