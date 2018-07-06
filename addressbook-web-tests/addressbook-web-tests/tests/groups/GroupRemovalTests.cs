using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    { 
        [Test]
        public void GroupRemovalTest()
        {
            
            if (!app.Groups.CheckGroup())
            {
                GroupData groupData = new GroupData("testName");
                app.Groups.Create(groupData);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData BeforDelOldGroups = oldGroups[0];

            app.Groups.Remove(BeforDelOldGroups);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.Sort();
            newGroups.Sort();
            
            oldGroups.RemoveAt(0);
 

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, BeforDelOldGroups.Id);
            }
        }
    }
}
