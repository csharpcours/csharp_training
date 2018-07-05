using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class UserData : IEquatable<UserData>,IComparable<UserData>
    {
        private string firstName;
        private string lastname;
        private string midleName ="";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email1 = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string secondaryHome = "";
        private string secondaryAddress = "";
        private string notes = "";
        private string year = "";
        private string ayear = "";

        public UserData(string firstName, string lastname)
        {
            this.firstName = firstName;
            this.lastname = lastname;
        }
        public UserData(string firstName)
        {
            this.firstName = firstName;            
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
            return firstName == other.firstName && lastname == other.lastname;
        }

        //public int GetHashCode()
        //{
        //    return firstName.GetHashCode();
        //    return lastname.GetHashCode();
        //}

        public override string ToString()
        {
            return "firstName = " + firstName + " lastName"  +  lastname;
        }

        public int CompareTo(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string MidleName
        {
            get
            {
                return midleName;
            }
            set
            {
                midleName = value;
            }
        }
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
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }
        public string Work
        {
            get
            {
                return work;
            }
            set
            {
                work = value;
            }
        }
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
        public string Email1
        {
            get
            {
                return email1;
            }
            set
            {
                email1 = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
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
        public string SecondaryHome
        {
            get
            {
                return secondaryHome;
            }
            set
            {
                secondaryHome = value;
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
            }
            set
            {
                ayear = value;
            }
        }
    }
}
