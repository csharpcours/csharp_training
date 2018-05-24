using NUnit.Framework;


namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {

            GroupData newData = new GroupData("ModifytestName");
            newData.GroupFooter = "ModifyFooterName";
            newData.GroupHeader = "ModifyGroupHeader";
            manager.Groups.Modify(1, newData);
        }

    }
}
