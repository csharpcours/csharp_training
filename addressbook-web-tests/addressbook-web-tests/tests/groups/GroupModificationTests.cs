using NUnit.Framework;


namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {

            GroupData newData = new GroupData("ModifytestName");
            newData.GroupFooter = null;// "ModifyFooterName";
            newData.GroupHeader = "ModifyGroupHeader";
            app.Groups.Modify(1, newData);
        }

    }
}
