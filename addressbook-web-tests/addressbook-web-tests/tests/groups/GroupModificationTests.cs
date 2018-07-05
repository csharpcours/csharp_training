using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.CheckGroup())
            {
                GroupData groupData = new GroupData("CreateForModifName");
                app.Groups.Create(groupData);
            }
            GroupData newData = new GroupData("ModifytestName");
            newData.GroupFooter = null;// "ModifyFooterName";
            newData.GroupHeader = "ModifyGroupHeader";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].GroupName = newData.GroupName;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            
            
            //Assert.IsTrue(app.Groups.CheckGroup());// временно т.к.этой проверки не достаточно             
            //Assert.Equals(app.Groups.TextByElementOnPage("ModifytestName"), "ModifytestName");
        }
    }
}
