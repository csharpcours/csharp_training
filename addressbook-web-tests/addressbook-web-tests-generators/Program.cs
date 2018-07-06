using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using EXEL= Microsoft.Office.Interop.Excel;



namespace addressbook_web_tests_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[1]);
            String filename = args[2];
            String type = args[0];
            String format = args[3];

            if (type == "group")
            {
                List<GroupData> groups = new List<GroupData>();

                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GeneraterandomString(10))
                    {
                        GroupHeader = TestBase.GeneraterandomString(20),
                        GroupFooter = TestBase.GeneraterandomString(20)
                    });

                    if (format == "exel")
                    {
                        writeGroupToExelFile(groups, filename);
                    }
                    else
                    {
                        StreamWriter writer = new StreamWriter(args[2]);
                        if (format == "csv")
                        {
                            writeGroupToCSVFile(groups, writer);
                        }
                        else if (format == "xml")
                        {
                            writeGroupToXMLFile(groups, writer);
                        }
                        else if (format == "json")
                        {
                            writeGroupToJSONFile(groups, writer);
                        }
                        else
                        {
                            System.Console.Out.Write("Unrecognize formar" + format);
                        }
                        writer.Close();
                    }
                }
            }
            if (type == "contact")
            {
                List<UserData> users = new List<UserData>();
                for (int i = 0; i < count; i++)
                {
                    users.Add(new UserData(TestBase.GeneraterandomString(10))
                    {
                        MidleName = TestBase.GeneraterandomString(20),
                        Lastname = TestBase.GeneraterandomString(20),
                        Address = TestBase.GeneraterandomString(20),
                        Email1 = TestBase.GeneraterandomString(20),
                        Email2 = TestBase.GeneraterandomString(20),
                        Email3 = TestBase.GeneraterandomString(20),
                        Mobile = TestBase.GeneraterandomString(20),
                        SecondaryHome = TestBase.GeneraterandomString(20),
                        Home = TestBase.GeneraterandomString(20),
                        Work = TestBase.GeneraterandomString(20)
                    });
                }
                if (format == "exel")
                {
                    writeUserToExelFile(users, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(args[2]);
                    if (format == "csv")
                    {
                        writeUserToCSVFile(users, writer);
                    }
                    else if (format == "xml")
                    {
                        writeUserToXMLFile(users, writer);
                    }
                    else if (format == "json")
                    {
                        writeUserToJSONFile(users, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognize formar" + format);
                    }
                    writer.Close();
                }
            }
           

        }

            static void writeGroupToCSVFile(List<GroupData> groups,StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.GroupName, group.GroupHeader, group.GroupHeader));
            }
        }
        static void writeGroupToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupToExelFile(List<GroupData> groups, string filename)
        {
                EXEL.Application app = new EXEL.Application();
                app.Visible = true;
                EXEL.Workbook wb = app.Workbooks.Add();
                EXEL.Worksheet sheet = wb.ActiveSheet;
                //sheet.Cells[1, 1] = "test";
            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.GroupName;
                sheet.Cells[row, 2] = group.GroupHeader;
                sheet.Cells[row, 3] = group.GroupFooter;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Visible =false;
            app.Quit();
        }

        static void writeGroupToJSONFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeUserToCSVFile(List<UserData> users, StreamWriter writer)
        {
            foreach (UserData user in users)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},${9}",
                    user.MidleName,
                    user.Lastname,
                    user.Address,
                    user.Email1,
                    user.Email2,
                    user.Email3,
                    user.Mobile,
                    user.Home,
                    user.Work,
                    user.SecondaryHome
                    ));

            }
        }
        static void writeUserToExelFile(List<UserData> users, string filename)
        {

            EXEL.Application app = new EXEL.Application();
            app.Visible = true;
            EXEL.Workbook wb = app.Workbooks.Add();
            EXEL.Worksheet sheet = wb.ActiveSheet;
            //sheet.Cells[1, 1] = "test";
            int row = 1;
            foreach (UserData user in users)
            {
                sheet.Cells[row, 1] = user.FirstName;
                sheet.Cells[row, 2] = user.MidleName;
                sheet.Cells[row, 3] = user.Lastname;
                sheet.Cells[row, 4] = user.Address;
                sheet.Cells[row, 5] = user.Email1;
                sheet.Cells[row, 6] = user.Email2;
                sheet.Cells[row, 7] = user.Email3;
                sheet.Cells[row, 8] = user.Mobile;
                sheet.Cells[row, 9] = user.Home;
                sheet.Cells[row, 10] = user.Work;
                sheet.Cells[row, 11] = user.SecondaryHome;
               
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Visible = false;
            app.Quit();
        }
        static void writeUserToXMLFile(List<UserData> users, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<UserData>)).Serialize(writer, users);
        }
        static void writeUserToJSONFile(List<UserData> users, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
