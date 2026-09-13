using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Change_Test_Specification;
using System.Windows.Forms;

namespace Change_Test_Specification.Classes
{
    class Make_New_XML
    {
        XmlDocument doc = new XmlDocument();
        private string file_path = Path.Combine(Application.StartupPath, @"..\..\res\xml\testcase.xml");

        XmlDocument doc2 = new XmlDocument();
        public string new_file_path = Path.Combine(Application.StartupPath, @"..\..\res\xml\path.xml");

        public void make_new_xml()
        {
            make_real_new_xml(file_path);
        }

        public void make_new_path_xml()
        {
            XmlElement root = doc2.CreateElement("Path_List");
            doc2.AppendChild(root);

            XmlElement path = doc2.CreateElement("path");
            path.InnerText = file_path;
            root.AppendChild(path);

            doc2.Save(new_file_path);
        }

        public void make_real_new_xml(string path)
        {
            XmlElement root = doc.CreateElement("Test");
            doc.AppendChild(root);

            XmlElement data = doc.CreateElement("Data");
            data.SetAttribute("id", "0");
            root.AppendChild(data);

            XmlElement data2 = doc.CreateElement("Test_name");
            data.AppendChild(data2);

            XmlElement data3 = doc.CreateElement("Min");
            data.AppendChild(data3);

            XmlElement data4 = doc.CreateElement("Max");
            data.AppendChild(data4);

            XmlElement data5 = doc.CreateElement("Voltage");
            data.AppendChild(data5);

            XmlElement data6 = doc.CreateElement("Measured_value");
            data.AppendChild(data6);

            XmlElement data7 = doc.CreateElement("Result");
            data.AppendChild(data7);

            doc.Save(path);
        }

        public void change_xml_file_name(string old_name , string new_name)
        { 
            
        }
    }
}