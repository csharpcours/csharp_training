using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
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
            newData.GroupFooter =  "ModifyFooterName";
            newData.GroupHeader = "ModifyGroupHeader";

            List<GroupData> oldGroups = GroupData.GetAll();//app.Groups.GetGroupList();
            GroupData BeforModifOldGroups = oldGroups[0];
            app.Groups.Modify(0, newData);
            //Assert.AreEqual(oldGroups.Count , app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll(); //app.Groups.GetGroupList();
            oldGroups[0].GroupName = newData.GroupName;

            

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == BeforModifOldGroups.Id)
                {
                    Assert.AreEqual(newData.GroupName,group.GroupName );
                }
            }
            //Assert.IsTrue(app.Groups.CheckGroup());// временно т.к.этой проверки не достаточно             
            //Assert.Equals(app.Groups.TextByElementOnPage("ModifytestName"), "ModifytestName");
        }
    }
}
