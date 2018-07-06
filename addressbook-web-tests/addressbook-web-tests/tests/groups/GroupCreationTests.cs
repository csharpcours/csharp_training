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
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomgroupDataProvaider()
        {
            List<GroupData> groupData = new List<GroupData>();
            for (int i = 0; i < 5; i++)
                groupData.Add(new GroupData(GeneraterandomString(30))
                {
                    GroupHeader = GeneraterandomString(100),
                    GroupFooter = GeneraterandomString(100)
                });
            return groupData;
        }

        public static IEnumerable<GroupData> GroupDataFromCSvFile()
        {
            List<GroupData> groupData = new List<GroupData>();
            string [] lines= File.ReadAllLines(@"group.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groupData.Add(new GroupData(parts[0])
                {
                    GroupHeader =parts[1],
                    GroupFooter= parts[2]
                });
            }
            return groupData;
        }

        public static IEnumerable<GroupData> GroupDataFromXMLFile()
        {
            List<GroupData> groupData = new List<GroupData>();
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>))
                                        .Deserialize(new StreamReader(@"group.xml"));
        }
             
        

        public static IEnumerable<GroupData> GroupDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"group.json"));
        }
        public static IEnumerable<GroupData> GroupDataFromEXELFile()
        {
            //return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"group.json"));
            List<GroupData> groupData = new List<GroupData>();
            EXEL.Application app = new EXEL.Application();
            EXEL.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), "@group.xlsx"));
            EXEL.Worksheet sheet = wb.ActiveSheet;
            EXEL.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groupData.Add(new GroupData()
                {
                  GroupName=  range.Cells[i,1].value,
                  GroupHeader = range.Cells[i, 2].value,
                  GroupFooter = range.Cells[i, 3].value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groupData;
        }


        [Test,TestCaseSource("GroupDataFromEXELFile")]
        public void GroupCreationTest(GroupData groupData)
        {

            //GroupData groupData = new GroupData("testName");
            //groupData.GroupFooter = "FooterName";

            List<GroupData> oldGroups = GroupData.GetAll();   //app.Groups.GetGroupList();
            app.Groups.Create(groupData);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            oldGroups.Add(groupData);

            

            List<GroupData> newGroups = GroupData.GetAll(); //app.Groups.GetGroupList();

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            //Assert.AreEqual(oldGroups.Count+1,newGroups.Count);
        }

        //[Test]
        //public void EmptyGroupCreationTest()
        //{       
        //    GroupData groupData = new GroupData("");
        //    groupData.GroupFooter = "";
        //    List<GroupData> oldGroups = app.Groups.GetGroupList();
        //    oldGroups.Add(groupData);
        //    app.Groups.Create(groupData);

        //    List<GroupData> newGroups = app.Groups.GetGroupList();
        //    oldGroups.Sort();
        //    newGroups.Sort();
            
        //    Assert.AreEqual(oldGroups, newGroups);
        //    //Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        //}
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData groupData = new GroupData("a'a");
            groupData.GroupFooter = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            oldGroups.Add(groupData);
            app.Groups.Create(groupData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            //Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test]
        public void TestsDBConnect()
        {
            //DateTime start = DateTime.Now;
            //List<GroupData> fromUi = app.Groups.GetGroupList();
            //DateTime end = DateTime.Now;
            //System.Console.WriteLine(end.Subtract(start));

            //start = DateTime.Now;
            //List<GroupData> fromDb = GroupData.GetAll();
            //end = DateTime.Now;
            //System.Console.WriteLine(end.Subtract(start));

            foreach (UserData contact in GroupData.GetAll()[0].GetContacts())
            {
                System.Console.Out.WriteLine(contact);
            }
        }

    }
}
