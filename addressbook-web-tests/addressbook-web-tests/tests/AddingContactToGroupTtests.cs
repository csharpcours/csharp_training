using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<UserData> oldList = group.GetContacts();
            UserData contact = UserData.GetAll().Except(oldList).First();

            List<UserData> list = UserData.GetAll();
            app.Users.AddContactToGroup(contact, group);

            //actions
            List<UserData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);        
        }
    }
}
