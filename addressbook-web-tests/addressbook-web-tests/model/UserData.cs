using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class UserData : IEquatable<UserData>,IComparable<UserData>
    {
        private string allPhones;
        private string allContact;
        private string allEmails;
        private string fio;
        //private string firstName;
        //private string lastname;
        // private string midleName = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
       // private string address = "";
       // private string home = "";
      //  private string mobile = "";
       // private string work = "";
        private string fax = "";
       // private string email1 = "";
       // private string email2 = "";
       // private string email3 = "";
        private string homepage = "";
       // private string secondaryHome = "";
        private string secondaryAddress = "";
        private string notes = "";
        private string year = "";
        private string ayear = "";

        public UserData(string firstName, string lastname)
        {
            FirstName = firstName;
            Lastname = lastname;
        }
        public UserData(string firstName)
        {
            FirstName = firstName;            
        }
        public UserData( )
        {
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
            return "firstName = " + FirstName + "\nlastName"  +  Lastname;
        }

        public int CompareTo(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
        }
        [Column(Name = "Id"),PrimaryKey]
        public string Id { get; set; }
        [Column(Name = "first")]
        public string FirstName { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "middlename")]
        public string MidleName { get; set; }
    
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string Home { get; set; }
        [Column(Name = "mobile")]
        public string Mobile { get; set; }
        [Column(Name = "work")]
        public string Work { get; set; }

        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        [Column(Name = "email")]
        public string Email1 { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
        public string SecondaryHome { get; set; }
        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string SecondaryAddress
        {
            get
            {
                return secondaryAddress;
            }
            set
            {
                secondaryAddress = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }
        public string Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
        public string Ayear
        {
            get
            {
                return ayear;
            } set
            {
                ayear = value;
            }
        }
        
        public static List<UserData> GetAll()
       {
            using (AddressBookDB db = new AddressBookDB())
           {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();

           }
       }
public string AllPhones
        {       
            get {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile)+CleanUp(Work)+ CleanUp(SecondaryHome)).Trim();
                }
            }

            set{
                allPhones = value;
            }
        }
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone,"[ -()]","")  + "\r\n";
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                if (Email2 == ""&& Email3=="")
                {
                    return Email1;
                }
                if (Email2 == "" )
                {
                    return LineBreak(Email1) + LineBreak(Email3);
                }
                if (Email3 == "")
                {
                    return LineBreak(Email1) + Email2;
                }
                else
                {
                    return LineBreak(Email1)  + LineBreak(Email2)  + Email3;
                }
            }

            set
            {
                allEmails = value;
            }
        }

        private string LineBreak(string mail)
        {
            if (mail == null || mail == "")
            {
                return "";
            }
            return mail+ "\r\n";
        }

        public string AllContact //= allContact
        {
            get
            {
                if (allContact != null)
                {
                    return allContact;
                }
                else {
                    return  LineBreak(FIO)+ LineBreak(LineBreak(Address)) + "H: " + LineBreak(Home) + ("M: ") + LineBreak(Mobile) + ("W: ")+ LineBreak(LineBreak(Work)) + LineBreak(LineBreak(LineBreak(LineBreak(AllEmails))))+ ("P: ")+SecondaryHome;
                }

            }
            set
            {
                allContact = value;
            }
        }
        public string FIO//FirstName + " " + MidleName + " " + LineBreak(Lastname)
                         //private string firstName;
                         //private string lastname;
                         // private string midleName = "";
        {
            get
            {
                if (fio != null&&fio=="")
                {
                    return fio;
                }
                //if (lastname == "" && midleName == "")
                //{
                //    return firstName;
                //}
                //if (lastname == "")
                //{
                //    return (firstName) + (midleName);
                //}
                if (MidleName == "")
                {
                    return (FirstName) +" "+ Lastname;
                }
                else
                {
                    return (FirstName) +" "+ MidleName+" " + (Lastname);
                }
            }

            set
            {
                fio = value;
            }
        }


    }
}
