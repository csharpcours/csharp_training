using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [Table(Name ="group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
       // private string groupName;
       // private string groupHeader = "";
       // private string groupFooter = "";

        public GroupData(string groupName)
        {
            GroupName = groupName;
        }
        public GroupData()
        {
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

        public override int GetHashCode()
        {
            return GroupName.GetHashCode();
        }

        public override string ToString()
        {
            return "GroupName = " + GroupName+ "\nGroupHeader" + GroupHeader + "\nGroupFooter" + GroupFooter;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return GroupName.CompareTo(other.GroupName);
        }


        [Column(Name ="group_name")]
        public string GroupName { get; set; }
        [Column(Name = "group_header")]
        public string GroupHeader { get; set; }
        [Column(Name = "group_footer")]
        public string GroupFooter { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();

            }
        }
        public static List<GroupData> GetGroups()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups
                        from gcr in db.GCR.Where(p => p.Groupid == g.Id)
                        select g).Distinct().ToList();
            }
        }
public List<UserData> GetContacts()
        {
           using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.Groupid == Id && p.Contactid == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }
        

        public string Id { get; set; }
    }
}
