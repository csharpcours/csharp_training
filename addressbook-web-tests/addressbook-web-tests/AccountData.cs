using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class AccountData
    {
        private string userName;
        private string pass;

        public AccountData(string userName, string pass)
        {
            this.userName = userName;
            this.pass = pass;
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public string Pass
        {
            get
            {
                return pass;
            }
            set
            {
                pass = value;
            }
        }
    }
}
