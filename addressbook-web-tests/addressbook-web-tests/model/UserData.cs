using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class UserData : IEquatable<UserData>,IComparable<UserData>
    {
        //private string firstName;
        //private string lastname;
        //private string midleName ="";
        //private string nickname = "";
        //private string title = "";
        //private string company = "";
        //private string address = "";
        //private string home = "";
        //private string mobile = "";
        //private string work = "";
        //private string fax = "";
        //private string email1 = "";
        //private string email2 = "";
        //private string email3 = "";
        //private string homepage = "";
        //private string secondaryHome = "";
        //private string secondaryAddress = "";
        //private string notes = "";
        //private string year = "";
        //private string ayear = "";

        public UserData(string firstName, string lastname)
        {
            FirstName = firstName;
            Lastname = lastname;
        }
        public UserData(string firstName)
        {
            FirstName = firstName;            
        }
        public bool Equals(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && Lastname == other.Lastname;
        }

        //public int GetHashCode()
        //{
        //    return firstName.GetHashCode();
        //    return lastname.GetHashCode();
        //}

        public override string ToString()
        {
            return "firstName = " + FirstName + " lastName"  +  Lastname;
        }

        public int CompareTo(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
        }

        public string FirstName { get; set; }
 
        public string Lastname { get; set; }
      
        public string MidleName { get; set; }
        
        public string Nickname { get; set; }
       
        public string Title { get; set; }
        public string Company { get; set; }
        
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string SecondaryHome { get; set; }
        public string SecondaryAddress { get; set; }
        public string Notes { get; set; }
        public string Year  { get; set; }
        public string Ayear { get; set; }
        public string Id { get; set; }
    }
}
