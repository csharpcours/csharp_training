using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>
    {
        private string groupName;
        private string groupHeader = "";
        private string groupFooter = "";

        public GroupData(string groupName)
        {
            this.groupName = groupName;
        }
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return GroupName == other.GroupName;
        }

        public int GetHashCode()
        {
            return GroupName.GetHashCode();
        }
        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }
        public string GroupHeader
        {
            get
            {
                return groupHeader;
            }
            set
            {
                groupHeader = value;
            }
        }
        public string GroupFooter
        {
            get
            {
                return groupFooter;
            }
            set
            {
                groupFooter = value;
            }
        }

    }
}
