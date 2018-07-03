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
            //List<GroupData> oldGroups = app.Groups.GetGroupist();
            if (!app.Groups.CheckGroup())
            {
                GroupData groupData = new GroupData("testName");
                app.Groups.Create(groupData);
            }            
            app.Groups.Remove(0);


            //List<GroupData> newGroups = app.Groups.GetGroupist();

            // oldGroups.RemoveAt(0);
            // Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
