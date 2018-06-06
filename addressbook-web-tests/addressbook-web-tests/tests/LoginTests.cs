using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithVaidCredentias()
        {
          
            app.LogOnOff.Logout();
            AccountData account = new AccountData("admin", "secret");
            app.LogOnOff.Login(account);
            Assert.IsTrue(app.LogOnOff.isLoggedIn(account));
        }

        [Test]
        public void LoginWithInvaidCredentias()
        {

            app.LogOnOff.Logout();

            AccountData account = new AccountData("admin", "12345");
            app.LogOnOff.Login(account);
            Assert.IsFalse(app.LogOnOff.isLoggedIn(account));
        }
    }
}
