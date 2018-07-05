using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    { 
        [Test]
        public void GroupRemovalTest()
        {
           
            if (!app.Groups.CheckGroup())
            {
                GroupData groupData = new GroupData("testName");
                app.Groups.Create(groupData);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Sort();
            newGroups.Sort();
            GroupData BeforDelOldGroups = oldGroups[0];
            oldGroups.RemoveAt(0);
 

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, BeforDelOldGroups.Id);
            }
        }
    }
}
