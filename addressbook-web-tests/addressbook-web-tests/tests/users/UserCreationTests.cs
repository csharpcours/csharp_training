using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using EXEL = Microsoft.Office.Interop.Excel;




namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : AuthTestBase
    {

        public static IEnumerable<UserData> RandomgroupDataProvaider()
        {
            List<UserData> userData = new List<UserData>();
            for (int i = 0; i < 5; i++)
                userData.Add(new UserData(GeneraterandomString(30))
                {
                    MidleName = GeneraterandomString(100),
                    Lastname = GeneraterandomString(100)
                });
            return userData;
        }

        public static IEnumerable<UserData> UserDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<UserData>>(File.ReadAllText(@"contact.json"));
        }

        public static IEnumerable<UserData> UserDataFromCSVFile()
        {
            List<UserData> userData = new List<UserData>();
            string[] lines = File.ReadAllLines(@"contact.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                userData.Add(new UserData(parts[0])
                {
                    FirstName = parts[1],
                    MidleName = parts[2]
                });
            }
            return userData;
        }
        public static IEnumerable<UserData> UserDataFromXMLFile()
        {
            List<UserData> userData = new List<UserData>();
            return (List<UserData>)new XmlSerializer(typeof(List<UserData>))
                                        .Deserialize(new StreamReader(@"contact.xml"));
        }
        public static IEnumerable<UserData> UserDataFromEXELFile()
        {
            //return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"group.json"));
            List<UserData> userData = new List<UserData>();
            EXEL.Application app = new EXEL.Application();
            EXEL.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), "@contact.xlsx"));
            EXEL.Worksheet sheet = wb.ActiveSheet;
            EXEL.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                userData.Add(new UserData()
                {
                    FirstName = range.Cells[i, 1].value,
                    Lastname = range.Cells[i, 2].value,
                    MidleName = range.Cells[i, 3].value,
                    Address = range.Cells[i, 4].value,
                    Email1 = range.Cells[i, 5].value,
                    Email2 = range.Cells[i, 6].value,
                    Email3 = range.Cells[i, 7].value,
                    Mobile = range.Cells[i, 8].value,
                    Home = range.Cells[i, 9].value,
                    Work = range.Cells[i, 10].value,
                    SecondaryHome = range.Cells[i, 11].value,
            });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return userData;
        }

        [Test, TestCaseSource("UserDataFromXMLFile")]
        public void UserCreationTest(UserData userData)
        {    
            //UserData userData = new UserData("FirstName", "LastName");
            //userData.MidleName = "MiddleName";
            ////userData.Nickname = "Nickname";
            ////userData.Title = "Title";
            ////userData.Company = "Company";
            //userData.Address = "Address";
            //userData.Home = "Home";
            //userData.Mobile = "Mobile";
            //userData.Work = "Work";
            ////userData.Fax = "Fax";
            //userData.Email1 = "Email1";
            //userData.Email2 = "Email2";
            //userData.Email3 = "Email3";
            ////userData.Homepage = "Homepage";
            //userData.SecondaryHome = "SecondaryHome";
            ////userData.SecondaryAddress = "SecondaryAddress";
            ////userData.Notes = "Notes";
            ////userData.Year = "1988";
            ////userData.Ayear = "1988";

            List<UserData> oldContacts = app.Users.GetContactList();
            app.Users.Create(userData);

            Assert.AreEqual(oldContacts.Count + 1, app.Users.GetUserCount());

            List<UserData> newContacts = app.Users.GetContactList();
            oldContacts.Add(userData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }

        [Test]
        public void BadNameUserCreationTest()
        {
            UserData userData = new UserData("A'A", "LastName");
            
            List<UserData> oldContacts = app.Users.GetContactList();
            app.Users.Create(userData);
            List<UserData> newContacts = app.Users.GetContactList();
            Assert.AreEqual(oldContacts.Count , newContacts.Count);
            //Assert.AreEqual(oldContacts.Count+1, newContacts.Count);
        }
    }
}
