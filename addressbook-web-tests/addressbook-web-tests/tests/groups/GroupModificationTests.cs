using NUnit.Framework;


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
            
            app.Groups.Modify(0, newData);
            
            //Assert.IsTrue(app.Groups.CheckGroup());// временно т.к.этой проверки не достаточно             
            //Assert.Equals(app.Groups.TextByElementOnPage("ModifytestName"), "ModifytestName");
        }
    }
}
